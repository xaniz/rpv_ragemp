$(document).ready(function(){
	//смена форм(доработка)
	$('#reg_form_show').on('click',function(){
		console.log("hello");
		$('#auth-form').css('display','none');
		$('#reg-form').css('display','block');
		
		$('#auth_form_show').removeClass('underline_a');
		$('#reg_form_show').addClass('underline_a');
	});
	$('#auth_form_show').on('click',function(){
		$('#auth-form').css('display','block');
		$('#reg-form').css('display','none');
		$('#reg_form_show').removeClass('underline_a');
		$('#auth_form_show').addClass('underline_a');
	});
});