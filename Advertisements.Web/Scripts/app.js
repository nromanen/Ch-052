function ViewModel() {
    var self = this;

    var tokenKey = 'accessToken';

    self.result = ko.observable();
    self.user = ko.observable();

    self.registerEmail = ko.observable();
    self.registerPassword = ko.observable();
    self.registerPassword2 = ko.observable();

    self.loginEmail = ko.observable();
    self.loginPassword = ko.observable();
    self.errors = ko.observableArray([]);

    function showError(jqXHR) {

        self.result(jqXHR.status + ': ' + jqXHR.statusText);

        var response = jqXHR.responseJSON;
        if (response) {
            if (response.Message) self.errors.push(response.Message);
            if (response.ModelState) {
                var modelState = response.ModelState;
                for (var prop in modelState)
                {
                    if (modelState.hasOwnProperty(prop)) {
                        var msgArr = modelState[prop]; // expect array here
                        if (msgArr.length) {
                            for (var i = 0; i < msgArr.length; ++i) self.errors.push(msgArr[i]);
                        }
                    }
                }
            }
            if (response.error) self.errors.push(response.error);
            if (response.error_description) self.errors.push(response.error_description);
        }
    }

    self.callApi = function () {
        self.result('');
        self.errors.removeAll();

        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'GET',
            url: '/api/values',
            headers: headers
        }).done(function (data) {
            self.result(data);
        }).fail(showError);
    }

	self.register = function () {

		var form = $('#signupForm');
		if (!form.valid())
			return;

        self.result('');
        self.errors.removeAll();

        var queryData = {
			UserName: $('#firstName').val() + ' ' + $('#surName').val(),
			Email: $('#eMail').val(),
			Password: $('#password').val(),
			ConfirmPassword: $('#passwordRepeat').val()
        };

		$.ajax({
			type: 'POST',
			url: '/api/Account/Register',
			contentType: 'application/json; charset=utf-8',
			data: JSON.stringify(queryData),
			success: function () {
				
				self.result("Done!");
				alert('Registration success, check your email to confirm your account ');
				window.location.replace('/Home/Index');
			},
			fail: function (data) {
				alert('Registration failed:' + data.responseJSON.Message);
			},
			error: function (data) {
				alert('Registration failed:' + data.responseJSON.Message);
			}			
		});
		
    }

    self.login = function () {
        self.result('');
        self.errors.removeAll();

        var loginData = {
			grant_type: 'password',
			Email: $('#useremail').val(),
			Password: $('#userpassword').val(),
			UserName: $('#useremail').val()
        };

		$.ajax({
			type: 'POST',
			url: '/Token',
			data: loginData,
			success: function (data) {
				self.user(data.userName);
				// Cache the access token in session storage.
				sessionStorage.setItem(tokenKey, data.access_token);
				window.location.replace('/Home/Index');
			},
			fail: function (data) { alert(data.responseJSON.Message); },
			error: function (data) { alert(data.responseJSON.Message); }
		});
	}

	self.restorePassByEmail = function ()
	{
		var form = $('#emailForm');
		if (!form.valid())
			return;

		var restoreData = {
			eMail: $('#emailInput').val()
		};
		$.ajax({
			type: 'POST',
			url: '/api/Account/RestorePasswordRequest',
			data: restoreData,
			success: function (data, state) { alert(data) },
			fail: function (data, state) { alert(data.responseJSON.Message); },
			error: function (data, state) { alert(data.responseJSON.Message); }
		});
	}
	self.confirmPassword = function () {
		$('#confirmPasswordRestore').click(function () {
			var model = {
				NewPassword: $('#passwordForRestore').val(),
				Id: $('#modelId').val()
			}
			$.ajax({
				type: 'POST',
				url: '/api/Account/RestorePassword',
				data: model,
				success: function (data, state) { alert(data); },
				error: function (data, state) { alert(data); },
				fail: function (data, state) { alert(data); }
			})
		});
	}
    self.logout = function () {
        // Log out from the cookie based logon.
        var token = sessionStorage.getItem(tokenKey);
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }

        $.ajax({
            type: 'POST',
            url: '/api/Account/Logout',
            headers: headers
        }).done(function (data) {
            // Successfully logged out. Delete the token.
			self.user('');
			sessionStorage.removeItem(tokenKey); 
			window.location.replace('/Home/Index');
        }).fail(showError);
	}

	
}
var app = new ViewModel();
ko.applyBindings(app);