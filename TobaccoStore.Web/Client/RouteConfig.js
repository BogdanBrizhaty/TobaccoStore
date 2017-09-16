var routeConfig = app.config(['$routeProvider', ($routeProvider) => {
    $routeProvider.when('/', {
        templateUrl: 'Client/Views/General/Home.html',
        controller: 'HomeController'
    });
    $routeProvider.when('/test', {
        templateUrl: 'Client/Views/Partial/ProductList.html',
        controller: 'TobaccoController'
    });
    $routeProvider.when('/fumari', {
        templateUrl: 'Client/Views/Partial/ProductList.html',
        controller: 'TobaccoController'
    });
    $routeProvider.when('/serbentli', {
        templateUrl: 'Client/Views/Partial/ProductList.html',
        controller: 'TobaccoController'
    });
    $routeProvider.when('/alfakher', {
        templateUrl: 'Client/Views/Partial/ProductList.html',
        controller: 'TobaccoController'
    });
    $routeProvider.when('/darkside', {
        templateUrl: 'Client/Views/Partial/ProductList.html',
        controller: 'TobaccoController'
    });
    $routeProvider.when('/cart', {
        templateUrl: 'Client/Views/Partial/Cart.html',
        controller: 'CartController'
    });
    $routeProvider.when('/manage/:subview?', {
        templateUrl: function (params) {
            console.log(params.subview);
            return (params.subview === undefined)
                ? 'Client/Views/General/Manage.html'
                : 'Client/Views/Partial/Manage.' + params.subview + '.html';
        },
        controller: 'ManageController'
    });
    $routeProvider.when('/tobacco/:id', {
        templateUrl: 'Client/Views/General/Tobacco.html',
        controller: 'TobaccoController'
    });
    //$routeProvider.when('/tobacco/:id', {
    //    // controller here
    //    // temolate url here
    //});
}]);