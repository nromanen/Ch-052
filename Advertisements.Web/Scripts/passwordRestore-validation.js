$(document).ready(function () {
	$.validator.addMethod("additionalReq", function (value, element, param) {
		var reg = new RegExp(/^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{6,15}$/);
		return reg.test(value);
	}, "Password must contain at least of one uppercase character, one digit and one character");

	

	$('#restorePassForm').validate({
		rules:
		{
			passwordForRestore:
			{
				required: true,
				minlength: 6,
				maxlength: 15,
				additionalReq: true
			},
			passwordForRestoreConfirm:
			{
				required: true,
				minlength: 6,
				maxlength: 15,
				equalTo: '#passwordForRestore'
			}
		},
		messages:
		{
			passwordForRestore:
			{
				required: "Required field",
				minlength: "Password must contain at least of 6 characters",
				maxlength: "Password must contain maximum 15 characters",
			},
			passwordForRestoreConfirm:
			{
				required: "Required field",
				minlength: "Password must contain at least of 6 characters",
				maxlength: "Password must contain maximum 15 characters",
				equalTo: "Field must be the same as password"
			}
		},
		submitHandler: function (form) {   }
	});
});
