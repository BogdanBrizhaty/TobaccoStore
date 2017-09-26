app.controller('CartController', ['$scope', '$http', 'CartService', 'TobaccoService',
    function ($scope, $http, CartService, ProductService) {
        $scope.ProductsInCart = CartService.getAllProducts();
        angular.forEach($scope.ProductsInCart, (el) => {
            //console.log('id' + el.Id);
            $
        });
}]);