app.service('OrderService', function ($http) {
    var getOrder = (id) => {
        return $http.get('/api/Order/' + id);
    }
    var getOrders = (page) => {
        page = page >= 1 ? page : 1;
        return $http.get('/api/Order/page/' + page);
    }
    var addOrder = (item) => {
        var json = JSON.stringify(item);
        return $http.post('/api/Order/add', json);
    }
    var updateOrder = (item) => {
        var json = JSON.stringify(item);
        return $http.put('/api/Order/update', json);
    }
    var deleteOrder = (id) => {
        return $http.delete('/api/Order/' + id + '/delete', json);
    }

    return {
        getOrder: getOrder,
        getOrders: getOrders,
        addOrder: addOrder,
        updateOrder: updateOrder,
        deleteOrder: deleteOrder
    };
});