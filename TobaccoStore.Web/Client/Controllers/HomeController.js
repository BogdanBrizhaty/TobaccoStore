app.controller('HomeController', ['$scope', 'CartService', 'CredentialsService',
    function ($scope, CartService, CredentialsService) {
        var cart = localStorage.getItem('cart');
        if (cart === undefined || cart == null || cart == "")
            localStorage.setItem('cart', JSON.stringify([]));
        console.log('home');

        $scope.testHandler = () => {
            console.log('test handler activated successfully');
        }
        //CredentialsService.authenticate();
        sessionStorage.clear();
}]);