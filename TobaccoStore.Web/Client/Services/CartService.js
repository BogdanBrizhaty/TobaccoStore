app.service('CartService', function () {

    var addToCart = (item) => {
        var cart = JSON.parse(localStorage.getItem('cart'));
        var index = cart.findIndex(i => i.Id == item.Id);
        if (index > -1)
            return;
        cart.push(item);
        localStorage.setItem('cart', JSON.stringify(cart));
    }
    var removeFromCart = (id) => {
        var cart = JSON.parse(localStorage.getItem('cart'));
        var index = cart.findIndex(i => i.Id == id);
        if (index == -1)
            return;
        cart.splice(index, 1);
        localStorage.setItem('cart', JSON.stringify(cart));
    }
    var itemsInCart = () => {
        var cart = JSON.parse(localStorage.getItem('cart'));
        return cart.length;
    }
    var increase = (id, count) => {
        var cart = JSON.parse(localStorage.getItem('cart'));

        var index = cart.findIndex(i => i.Id == id);

        if (index == -1)
            return;

        cart[index].Amount += count;
        localStorage.setItem('cart', JSON.stringify(cart));
    };
    var decrease = (id, count) => {
        var cart = JSON.parse(localStorage.getItem('cart'));
        var index = cart.findIndex(i => i.Id == id);

        if (index == -1)
            return;

        cart[index].Amount -= count;

        if (cart[index].Amount < 1)
            cart[index].Amount = 1;

        localStorage.setItem('cart', JSON.stringify(cart));
    };
    var isInCart = (id) => {
        var cart = JSON.parse(localStorage.getItem('cart'));
        return (cart.findIndex(i => i.Id == id) == -1)
            ? false
            : true;
    };
    var getAllProducts = () => {
        var cart = JSON.parse(localStorage.getItem('cart'));
        return cart;
    };
    var clearCart = () => {
        localStorage.setItem('cart', '[]');
    };
    return {
        addProduct: addToCart,
        removeProduct: removeFromCart,
        increaseAmount: increase,
        decreaseAmount: decrease,
        isInCart: isInCart,
        itemsInCart: itemsInCart,
        getAllProducts: getAllProducts,
        clear: clearCart
    }
});