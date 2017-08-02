$(document).ready(function () {
	$('#signupForm').validate({
		rules: {
			firstName: 'required',
			surName: 'required',
			eMail: {
				required: true,
				email: true
			},
			password: {
				required: true,
				minlength: 6
			},
			passwordRepeat: {
				required: true,
				minlength: 6,
				equalTo: '#password'
			}
		},
		messages: {
			firstName: "Введіть своє ім'я",
			surName: "Введіть своє прізвище",
			eMail: {
				required: "Введіть свій емейл"
			},
			password: {
				required: "Треба ввести пароль",
				minlength: "Пароль повинен складати мінімум 6 символів"
			},
			passwordRepeat: {
				required: "Введіть повторно пароль",
				minlength: "Пароль повинен складати мінімум 6 символів",
				equalTo: "Введіть такий самий пароль як вище"
			}
		},	
		submitHandler: function (form) { form.submit(); }
	});

}
);