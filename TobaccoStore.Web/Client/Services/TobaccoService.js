app.service('TobaccoService', function ($http) {
    var getProduct = (id) => {
        return $http.get('/api/tobacco/' + id);
    }
    var getProducts = (page, manufacturer) => {
        page = page >= 1 ? page : 1;
        return $http.get('/api/tobacco/page/' + page + '/?manufacturerId=' + manufacturer + '&pageSize=8');
    }
    // get all here
    var findProducts = (q, page) => {
        page = page >= 1 ? page : 1;
        return $http.get('/api/tobacco/search/' + q + '/page/' + page);
    }
    var addProduct = (item) => {
        var json = JSON.stringify(item);
        return $http.post('/api/tobacco/add', json);
    }
    var updateProduct = (item) => {
        var json = JSON.stringify(item);
        return $http.put('/api/tobacco/update', json);
    }
    var deleteProduct = (id) => {
        return $http.delete('/api/tobacco/' + id + '/delete', json);
    }

    return {
        getProduct: getProduct,
        getProducts: getProducts,
        findProducts: findProducts,
        addProduct: addProduct,
        updateProduct: updateProduct,
        deleteProduct: deleteProduct
    };
});