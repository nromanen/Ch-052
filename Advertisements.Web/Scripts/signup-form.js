$(document).ready(function () {	
	$.validator.addMethod("additionalReq", function (value, element, param) {
		var reg = new RegExp(/^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/);
		return reg.test(value);
	}, "Потрібно мінімум одну букву верхнього регістру, цифру та один символ");

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
				minlength: 6,
				maxlength: 15,
				additionalReq: true				
			},
			passwordRepeat: {
				required: true,
				minlength: 6,
				maxlength: 15,
				equalTo: '#password'
			}
		},
		messages: {
			firstName: "Введіть своє ім'я",
			surName: "Введіть своє прізвище",
			eMail: {
				required: "Поле обов'язкове для заповнення"
			},
			password: {
				required: "Поле обов'язкове для заповнення",
				minlength: "Пароль повинен складати мінімум 6 символів",
				maxlength: "Пароль повинен складати максимум 15 символів",
			},
			passwordRepeat: {
				required: "Поле обов'язкове для заповнення",
				minlength: "Пароль повинен складати мінімум 6 символів",
				maxlength: "Пароль повинен складати максимум 15 символів",
				equalTo: "Введіть такий самий пароль як вище"
			}
		},
		submitHandler: function (form) { form.submit(); }
	});

}
);