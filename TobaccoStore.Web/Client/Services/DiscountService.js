app.service('DiscountService', function ($http) {
    var getDiscount = (id) => {
        return $http.get('/api/discount/' + id);
    }
    var getDiscounts = (page) => {
        page = page >= 1 ? page : 1;
        return $http.get('/api/discount/page/' + page);
    }
    var addDiscount = (item) => {
        var json = JSON.stringify(item);
        return $http.post('/api/discount/add', json);
    }
    var updateDiscount = (item) => {
        var json = JSON.stringify(item);
        return $http.put('/api/discount/update', json);
    }
    var deleteDiscount = (id) => {
        return $http.delete('/api/discount/' + id + '/delete', json);
    }

    return {
        getDiscount: getDiscount,
        getDiscounts: getDiscounts,
        addDiscount: addDiscount,
        updateDiscount: updateDiscount,
        deleteDiscount: deleteDiscount
    };
});