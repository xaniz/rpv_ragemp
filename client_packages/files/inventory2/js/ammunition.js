$(document).ready(function(){
	$('.show_box-element').on('click',function(){
		var title = $(this).find('#content_title').html();
		var price = $(this).find('#content_price').html();
		$('#weapon_title').html(title);
		$('#weapon_price').html(price);
		$('#weapon_pict').attr('src','img/'+title+'.png');
	});
	
	$('.ammo-nav-btn').on('click',function(){
		var name = $(this).html();
		$('.ammo-nav-btn').removeClass('active-nav-btn');
		$(this).addClass('active-nav-btn');
		
		$('#Melee_block').hide();
		$('#Ammo_block').hide();
		$('#Bullet_block').hide();
		
		if(name=="Melee"){
			$('#Melee_block').show();
		}else if(name=="Pistol"){
			$('#Ammo_block').show();
		}else{
			$('#Bullet_block').show();
		}
	});
	
	$(document).on('keydown',function(e){
		if(e.key=="e")ammunationCloseWindow();
	});
	$('.exit_info').on('click',function(){
		ammunationCloseWindow();
	});
});