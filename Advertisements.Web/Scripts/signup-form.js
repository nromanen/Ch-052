$(document).ready(function () {	
	$.validator.addMethod("additionalReq", function (value, element, param) {
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
			}
		},
		submitHandler: function (form) { form.submit(); }
	});

}
);