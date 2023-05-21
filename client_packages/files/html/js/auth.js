; (function ($) {

    $.fn.toJSON = function () {
        var $elements = {};
        var $form = $(this);
        $form.find('input, select, textarea').each(function () {
            var name = $(this).attr('name')
            var type = $(this).attr('type')
            if (name) {
                var $value;
                if (type == 'radio') {
                    $value = $('input[name=' + name + ']:checked', $form).val()
                } else if (type == 'checkbox') {
                    $value = $(this).is(':checked')
                } else {
                    $value = $(this).val()
                }
                $elements[$(this).attr('name')] = $value
            }
        });
        return JSON.stringify($elements)
    };
    $.fn.fromJSON = function (json_string) {
        var $form = $(this)
        var data = JSON.parse(json_string)
        $.each(data, function (key, value) {
            var $elem = $('[name="' + key + '"]', $form)
            var type = $elem.first().attr('type')
            if (type == 'radio') {
                $('[name="' + key + '"][value="' + value + '"]').prop('checked', true)
            } else if (type == 'checkbox' && (value == true || value == 'true')) {
                $('[name="' + key + '"]').prop('checked', true)
            } else {
                $elem.val(value)
            }
        })
    };
}(jQuery));



function checkCode(str) {
    let ascii;
    for (let i = 0; i != str.length; i++) {
        ascii = str.charCodeAt(i);
        if (ascii < 48 || ascii > 57) return false;
    }
    return true;
}

var restPassState = false;
var restPass = null;
var registerBtn = null;
var restoreBtn = null;
var authBackBtn = null;
var authBtn = null;
var endRegisterBtn = null;
var endRestoreBtn = null;
var authPage = null;
var regPage = null;
var restPage = null;
var slotsPage = null;
var slotL = null;
var slotM = null;
var slotR = null;

$(document).ready(() => {
    restPass = $('.entry-login');
    restoreBtn = $('.js-btn-restore');
    registerBtn = $('.js-btn-register');
    authBackBtn = $('.js-btn-back');
    authBtn = $('.js-btn-auth');
    endRegisterBtn = $('.btn-register-end');
    endRestoreBtn = $('.btn-restore-end');
    authPage = $('.auth-page');
    regPage = $('.reg-page');
    restPage = $('.rest-page');
    slotsPage = $('.slots-page');
    slotL = $('.col-l');
    slotM = $('.col-m');
    slotR = $('.col-r');

    // Переход на страницу авторизации (клик на "Регистрация")
    registerBtn.on('click', (e) => {
        e.preventDefault();
        authPage.removeClass('show');
        regPage.addClass('show');
    });

    // Переход на страницу восстановления пароля (клик на 'Восстановить')
    restoreBtn.on('click', (e) => {
        e.preventDefault();
        authPage.removeClass('show');
        restPage.addClass('show');
    });

    // Возврат на страницу авторизации (клик на "Назад")
    authBackBtn.on('click', (e) => {
        e.preventDefault();
        if (restPassState) {
            restPassState = false;
            restPass.attr('placeholder', 'Login / E-mail');
        }
        regPage.removeClass('show');
        restPage.removeClass('show');
        authPage.addClass('show');
    });

    // Сохраниние данных с полей (Авторизация - Кнопка "Войти")
    authBtn.on('click', () => {
        let authData = $('#auth-form').toJSON();
        mp.trigger('signin', authData);
        localStorage['form_data'] = authData;
        return false;
    });

    // Сохраниние данных с полей (Регистрация - Кнопка "Зарегистрироваться")
    endRegisterBtn.on('click', () => {
        let regData = $('#reg-form').toJSON();
        mp.trigger('signup', regData);
        localStorage['form_data'] = regData;
        return false;
    });
	
    // Сохранение данных с полей (Восстановление пароля - Кнопка "Вспомнить")
    endRestoreBtn.on('click', (e) => {
        let regData = $('#rest-form').toJSON();
        let myval = document.getElementById("rest-form").elements[0].value;
        if (!restPassState) {
            e.preventDefault();
            if (myval.length != 0) {
                restPassState = true;
                restPass.attr('placeholder', 'Code from the email');
                restPass.val('');
                mp.trigger('restorepass', 0, regData);
                localStorage['form_data'] = regData;
            }
        } else {
            if (myval.length == 4) {
                if (checkCode(myval)) mp.trigger('restorepass', 1, regData);
                else restPass.val('');
            } else restPass.val('');
        }
        return false;
    });
});

$(document).ready(function(){
	//смена форм(доработка)
	$('#reg_form_show').on('click',function(){
		console.log("hello");
		$('.auth-form').css('display','none');
		$('.reg-form').css('display','block');
		$('#reg_form_show').removeClass('underline_a');
		$('#auth_form_show').addClass('underline_a');
	});
	$('#auth_form_show').on('click',function(){
		$('.auth-form').css('display','block');
		$('.reg-form').css('display','none');
		$('#auth_form_show').removeClass('underline_a');
		$('#reg_form_show').addClass('underline_a');
	});
});