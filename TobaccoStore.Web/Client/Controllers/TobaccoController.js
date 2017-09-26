app.controller('TobaccoController', ['$scope', '$http', '$routeParams', '$location', 'TobaccoService', 'CartService',
    function ($scope, $http, $routeParams, $location, TobaccoService, CartService) {

    var updateCartView = () => {
        //$rootScope.cartInfo = CartService.itemsInCart();
        //$rootScope.$apply();
        $('#cart-count').html(CartService.itemsInCart());
    }

    var locations = ['fumari', 'serbentli', 'alfakher', 'darkside', 'test', 'batu'];

    updateCartView();

    $scope.goToPage = (page) => {
        if (page == $scope.currentPage)
            return;

        var curLocation = $location.path();

        var tid = 1 + locations.indexOf(curLocation.replace('/', ''));

        TobaccoService.getProducts(page, tid).then((e) => {
            $scope.ProductList = e.data.Items;
            $scope.currentPage = page;
            $scope.totalItems = e.data.Count;
            $scope.totalPages = (Math.ceil($scope.totalItems / 8));
            console.log('loaded');
            $('#content-holder').removeClass('d-none').addClass('d-block');
            $('#preloader-holder').removeClass('d-block').addClass('d-none');
        });
    };
    $scope.getImage = function (data) {
        //console.log('img = ' + data);
        return (data === undefined || data == null || data == '')
            ? '/Content/emptyfile.png'
            : 'data:image/png;base64,' + data;
    };
    $scope.Count = 1;
    if ($routeParams.id !== undefined) {
        console.log('TID ' + $routeParams.id);
        TobaccoService.getProduct($routeParams.id).then((e) => {
            $scope.TobaccoInfo = e.data;

            if ($scope.TobaccoInfo.PackageInfoes.length > 0)
                $scope.selectedPackaging = $scope.TobaccoInfo.PackageInfoes[0];
        });
    }
    $scope.incCount = () => {
        $scope.Count++;
    }
    $scope.decCount = () => {
        if ($scope.Count > 1)
            $scope.Count--;
    }
    $scope.isInCart = (id) => {
        return CartService.isInCart(id);
    };

    $scope.selectPackageWeight = (packageInfo) => {
        $scope.selectedPackaging = packageInfo;

    };

    var addToCart = () => {
        $http.get('/api/tobacco/manufacturers/' + $scope.TobaccoInfo.Manufacturer_Id).then(d => {
            CartService.addProduct({
                Id: $scope.TobaccoInfo.Id,
                Name: $scope.TobaccoInfo.Name,
                Manufacturer_Id: $scope.TobaccoInfo.Manufacturer_Id,
                ManufacturerName: d.data.Name,
                ListPrice: $scope.TobaccoInfo.Price,
                Price: $scope.Count * $scope.TobaccoInfo.Price,
                Amount: $scope.Count
            });
            updateCartView();

        });
    };
    var removeFromCart = () => {
        CartService.removeProduct($scope.TobaccoInfo.Id);
        updateCartView();
    };
    
    $scope.addToCartBtnClick = () => {
        if ($scope.isInCart($scope.TobaccoInfo.Id))
            removeFromCart();
        else
            addToCart();
    }


    // implemented to be used in tobacco list
    //$scope.addToCartHndlr = () => {
    //    var sender = event.currentTarget.parentElement.parentElement;
    //    var link = $(sender).first().find('.product-link');
    //    $.each(link, (i, el) => {
    //        var match = el.href.match(/tobacco\/\d+/g);
    //        var intId = parseInt(match[0].replace('tobacco/', ''));
    //        $http.get('/api/tobacco/' + intId).then((e) => {
    //            var manufacturerId = e.data.Manufacturer_Id;
    //            $http.get('/api/tobacco/manufacturers/' + manufacturerId).then(d => {
    //                CartService.addProduct({
    //                    Id: intId,
    //                    Name: e.data.Name,
    //                    Manufacturer_Id: manufacturerId,
    //                    ManufacturerName: d.data.Name,
    //                    ListPrice: e.data.Price,
    //                    Price: e.data.Price,
    //                    Amount: 1
    //                });
    //            });
    //        });
    //    });
    //    var cont = $(sender).find(".btn-container").first();
    //    cont.html('<a class="add-to-cart half-opacity" onclick="removeFromCartEventHandler()">Убрать</a>');

    //    console.log('items in cart: ' + CartService.itemsInCart());
    //    $scope.itemsCount = CartService.itemsInCart();
    //};
    //$scope.removeFromCartHndlr = () => {
    //    var sender = event.currentTarget.parentElement.parentElement;
    //    var link = $(sender).first().find('.product-link');
    //    $.each(link, (i, el) => {
    //        var match = el.href.match(/tobacco\/\d+/g);
    //        var intId = parseInt(match[0].replace('tobacco/', ''));
    //        CartService.removeProduct(intId);
    //    });
    //    var cont = $(sender).find(".btn-container").first();
    //    cont.html('<a class="add-to-cart" onclick="addToCartEventHandler()">Добавить в корзину</a>');

    //    console.log('items in cart: ' + CartService.itemsInCart());
    //    $scope.itemsCount = CartService.itemsInCart();
    //};
    //$scope.showButton = (id) => {
    //    var container = event.currentTarget.parentElement;
    //    var cont = $(container).find(".btn-container").first();
    //    if (CartService.isInCart(id))
    //    //    cont.html('<a class="add-to-cart half-opacity" ng-click="removeFromCart(' + id + ')" onclick="removeFromCartEventHandler()">Убрать</a>');
    //    //else
    //        cont.html('<a class="add-to-cart half-opacity" style="cursor: default;">В корзине</a>');
    //};
    $scope.goToPage(1);
}]);
