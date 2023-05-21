$(document).ready(function(){
	$('.blockSpawn').on('click',function(){
		$('.choosed_item').css('backgroundImage','url("")');
	   $('#infoped').hide();
	   $('#ul1').hide();
	   $('#ul2').hide();
	   $('#ul3').hide();
	   $('#ul4').hide();
	   $('#ul5').hide();
	   $('#ul6').hide();
	   
	   var name = $(this).find('.title').html();
	   
	   $('.block_title').html(name);
	   
	   if(name == "Получение лицензии"){
		   $('#ul1').show();
	   }else if(name == "Фракции"){
		   $('#ul2').show();
	   }else if(name == "Начальные работы"){
		   $('#ul3').show();
	   }else if(name == "Виды бизнесов"){
		   $('#ul4').show();
	   }else if (name == "Команды и кнопки"){
		   $('#ul5').show();
	   }else if (name == "Помощь игроку"){
		   $('#ul6').show();
	   }
	   $('.choosed_type_block').show();
	});
	
	$('.exit_block').on('click',function(){
	   $('#infoped').show();
	   $('.choosed_type_block').hide();
	});

	$('.exit_btn').on('click',function(){
		mp.trigger("Destroy_Character_Menu"); 
	});
});