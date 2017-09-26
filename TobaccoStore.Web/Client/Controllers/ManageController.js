app.controller('ManageController', ['$scope', '$route', '$routeParams', '$location', 'TobaccoService',
    function ($scope, $route, $routeParams, $location, TobaccoService) {
        $scope.addTobacco = () => {
            console.log('mng');
        };
        console.log(!!sessionStorage.getItem('authenticated'));

        //if (!sessionStorage.getItem('authenticated')) {
        //    console.log(sessionStorage.getItem('authenticated'));
        //    $route.redirectTo('/');
        //}
        //console.log($routeParams.subview);
        $scope.navigate = (path) => {
            if (path == 'all')
                $location.path('/manage/all');
            if (path == 'add')
                $location.path('/manage/add');
            if (path == 'change')
                $location.path('/manage/change');
        }

        $scope.ProductList = CartService.getProducts();
    }
]);