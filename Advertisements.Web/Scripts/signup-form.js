$(document).ready(function () {	
	$.validator.addMethod("additionalReq", function (value, element, param) {
<<<<<<< HEAD
		var reg = new RegExp(/^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,16}$/);
		return reg.test(value);
	}, "Потрібно мінімум одну букву верхнього регістру, цифру та один символ");

	$('#signupForm').validate({
		rules: {
			firstName: 'required',
			surName: 'required',
=======
		var reg = new RegExp(/^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,15}$/);
		return reg.test(value);
	}, "Password must contain 1 lowercase, 1 uppercase, 1 digit and one symbol");
	$.validator.addMethod("nameValidator", function (value, element, param) {
		var reg = new RegExp(/^[a-z ,.'-]+$/i);
		return reg.test(value);
	}, "Enter valid name");
	$.validator.addMethod("surnameValidator", function (value, element, param) {
		var reg = new RegExp(/^[a-z ,.'-]+$/i);
		return reg.test(value);
	}, "Enter valid surname");


	$('#signupForm').validate({
		rules: {
			firstName: {
				required: true,
				nameValidator: true
			},
			surName: {
				required: true,
				surnameValidator: true
			},
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
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
<<<<<<< HEAD
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
=======
			firstName: {
				required: "Required field"
			},
			surName: {
				required: "Required field"
			},
			eMail: {
				required: "Required field"
			},
			password: {
				required: "Required field",
				minlength: "Password must contain at least of 6 characters",
				maxlength: "Password length must be less than 15 characters",
			},
			passwordRepeat: {
				required: "Required field",
				minlength: "Password must contain at least of 6 characters",
				maxlength: "Password length must be less than 15 characters",
				equalTo: "Enter the same password as upper"
>>>>>>> 4e6b888bd9e10a264d0007078d4833eef042529d
			}
		},
		submitHandler: function (form) { form.submit(); }
	});

}
);