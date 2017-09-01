var routeConfig = app.config(['$routeProvider', ($routeProvider) => {
    $routeProvider.when('/', {
        templateUrl: 'Client/Views/Home.html',
        Controller: 'HomeController'
    });
    $routeProvider.when('/tobacco/:id', {
        // controller here
        // temolate url here
    });
}]);