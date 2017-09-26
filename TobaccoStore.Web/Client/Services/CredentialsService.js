app.service('CredentialsService', function ($http, $location) {
    var getToken = (email, password) => {
        //$http.get('')
        var loginData = {
            grant_type: 'password',
            username: 'bogdanbrizhaty@gmail.com',
            password: '..3JDs*s+s2323jk'
        };

        $.post('/token', loginData)
            .success((data) => {
                console.log(data.access_token);
                sessionStorage.setItem('token', data.access_token);
                sessionStorage.setItem('authenticated', true);
            })
        .fail((error) => {
            console.log(error.message);
        });

    }
    var logOut = () => {
        sessionStorage.removeItem('token');
    }
    return {
        authenticate: getToken,
        logout: logOut
    }
});