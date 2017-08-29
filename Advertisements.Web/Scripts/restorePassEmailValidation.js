$(document).ready(function () {
	$('#emailForm').validate({
		rules: {
			emailInput: {
				required: true,
				email: true
			}
		},
		messages: {
			emailInput: {
				required: "Required field",
				email: "Wrong email format"
			}
		},
		submitHandler: function (form) { }

	});
});