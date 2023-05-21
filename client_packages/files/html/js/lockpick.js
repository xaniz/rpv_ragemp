var _0xe15d = ['log', 'touchStart', 'touchList', 'css', 'now', 'span', 'text', 'find', '.top', '.bott', 'play', 'display', 'inline-block', '#modal', 'fadeIn', 'trigger', 'destroyBrowser', 'handleLockPickFailed', '#win', 'handleLockPickSuccess', 'min', 'max', 'convertRanges', 'random', '#pin', '#cylinder', '#driver', 'mousemove', 'clientX', 'clamp', 'rotateZ(', 'deg)', 'body', 'mouseleave', 'keydown', 'keyCode', 'keyup', 'touchstart'];
(function (_0x4e429f, _0x34377a) {
    var _0x58b703 = function (_0x442ed8) {
        while (--_0x442ed8) {
            _0x4e429f['push'](_0x4e429f['shift']());
        }
    };
    _0x58b703(++_0x34377a);
}
    (_0xe15d, 0x16d));
var _0xbec2 = function (_0x11bbd4, _0x2cd4f6) {
    _0x11bbd4 = _0x11bbd4 - 0x0;
    var _0x15e903 = _0xe15d[_0x11bbd4];
    return _0x15e903;
};
var minRot = -0x5a, maxRot = 0x5a, solveDeg = Math[_0xbec2('0x0')]() * 0xb4 - 0x5a, solvePadding = 0x4, maxDistFromSolve = 0x2d, pinRot = 0x0, cylRot = 0x0, lastMousePos = 0x0, mouseSmoothing = 0x2, keyRepeatRate = 0x19, cylRotSpeed = 0x3, pinDamage = 34, pinHealth = 0x64, pinDamageInterval = 0x96, numPins = 0x1, userPushingCyl = ![], gameOver = ![], gamePaused = ![], pin, cyl, driver, cylRotationInterval, pinLastDamaged;
$(function () {
    pin = $(_0xbec2('0x1'));
    cyl = $(_0xbec2('0x2'));
    driver = $(_0xbec2('0x3'));
    $('body')['on'](_0xbec2('0x4'), function (_0x57f45b) {
        if (lastMousePos && !gameOver && !gamePaused) {
            var _0x1347a6 = (_0x57f45b[_0xbec2('0x5')] - lastMousePos) / mouseSmoothing;
            pinRot += _0x1347a6;
            pinRot = Util[_0xbec2('0x6')](pinRot, maxRot, minRot);
            pin['css']({
                'transform': _0xbec2('0x7') + pinRot + _0xbec2('0x8')
            });
        }
        lastMousePos = _0x57f45b[_0xbec2('0x5')];
    });
    $(_0xbec2('0x9'))['on'](_0xbec2('0xa'), function (_0x27fd92) {
        lastMousePos = 0x0;
    });
    $('body')['on'](_0xbec2('0xb'), function (_0x857de4) {
        if ((_0x857de4['keyCode'] == 0x57 || _0x857de4[_0xbec2('0xc')] == 0x41 || _0x857de4[_0xbec2('0xc')] == 0x53 || _0x857de4[_0xbec2('0xc')] == 0x44 || _0x857de4[_0xbec2('0xc')] == 0x25 || _0x857de4[_0xbec2('0xc')] == 0x27) && !userPushingCyl && !gameOver && !gamePaused) {
            pushCyl();
        }
    });
    $('body')['on'](_0xbec2('0xd'), function (_0x439418) {
        if ((_0x439418[_0xbec2('0xc')] == 0x57 || _0x439418[_0xbec2('0xc')] == 0x41 || _0x439418[_0xbec2('0xc')] == 0x53 || _0x439418[_0xbec2('0xc')] == 0x44 || _0x439418[_0xbec2('0xc')] == 0x25 || _0x439418[_0xbec2('0xc')] == 0x27) && !gameOver) {
            unpushCyl();
        }
    });
    $(_0xbec2('0x9'))['on'](_0xbec2('0xe'), function (_0x397559) {
        console[_0xbec2('0xf')](_0xbec2('0x10'), _0x397559);
        if (!_0x397559[_0xbec2('0x11')]) {}
        else if (_0x397559[_0xbec2('0x11')]) {}
    });
});
function pushCyl() {
    var _0x168835,
    _0x578a1d;
    clearInterval(cylRotationInterval);
    userPushingCyl = !![];
    _0x168835 = Math['abs'](pinRot - solveDeg) - solvePadding;
    _0x168835 = Util[_0xbec2('0x6')](_0x168835, maxDistFromSolve, 0x0);
    _0x578a1d = Util['convertRanges'](_0x168835, 0x0, maxDistFromSolve, 0x1, 0.02);
    _0x578a1d = _0x578a1d * maxRot;
    cylRotationInterval = setInterval(function () {
        cylRot += cylRotSpeed;
        if (cylRot >= maxRot) {
            cylRot = maxRot;
            clearInterval(cylRotationInterval);
            unlock();
        } else if (cylRot >= _0x578a1d) {
            cylRot = _0x578a1d;
            damagePin();
        }
        cyl[_0xbec2('0x12')]({
            'transform': _0xbec2('0x7') + cylRot + _0xbec2('0x8')
        });
        driver[_0xbec2('0x12')]({
            'transform': _0xbec2('0x7') + cylRot + _0xbec2('0x8')
        });
    }, keyRepeatRate);
}
function unpushCyl() {
    userPushingCyl = ![];
    clearInterval(cylRotationInterval);
    cylRotationInterval = setInterval(function () {
        cylRot -= cylRotSpeed;
        cylRot = Math['max'](cylRot, 0x0);
        cyl[_0xbec2('0x12')]({
            'transform': 'rotateZ(' + cylRot + _0xbec2('0x8')
        });
        driver[_0xbec2('0x12')]({
            'transform': _0xbec2('0x7') + cylRot + _0xbec2('0x8')
        });
        if (cylRot <= 0x0) {
            cylRot = 0x0;
            clearInterval(cylRotationInterval);
        }
    }, keyRepeatRate);
}
function damagePin() {
    if (!pinLastDamaged || Date[_0xbec2('0x13')]() - pinLastDamaged > pinDamageInterval) {
        var _0x4edcf5 = new TimelineLite();
        pinHealth -= pinDamage;
        console[_0xbec2('0xf')]('damagePin,\x20pinHealth=', pinHealth);
        pinLastDamaged = Date[_0xbec2('0x13')]();
        _0x4edcf5['to'](pin, pinDamageInterval / 0x4 / 0x3e8, {
            'rotationZ': pinRot - 0x2
        });
        _0x4edcf5['to'](pin, pinDamageInterval / 0x4 / 0x3e8, {
            'rotationZ': pinRot
        });
        if (pinHealth <= 0x0) {
            breakPin();
        }
    }
}
function breakPin() {
    var _0x3a1dd0,
    _0x438cf1,
    _0x39e620;
    gamePaused = !![];
    clearInterval(cylRotationInterval);
    numPins--;
    $(_0xbec2('0x14'))[_0xbec2('0x15')](numPins);
    _0x438cf1 = pin[_0xbec2('0x16')](_0xbec2('0x17'));
    _0x39e620 = pin[_0xbec2('0x16')](_0xbec2('0x18'));
    _0x3a1dd0 = new TimelineLite();
    _0x3a1dd0['to'](_0x438cf1, 0.7, {
        'rotationZ': -0x190,
        'x': -0xc8,
        'y': -0x64,
        'opacity': 0x0
    });
    _0x3a1dd0['to'](_0x39e620, 0.7, {
        'rotationZ': 0x190,
        'x': 0xc8,
        'y': 0x64,
        'opacity': 0x0,
        'onComplete': function () {
            if (numPins > 0x0) {
                gamePaused = ![];
                reset();
            } else {
                outOfPins();
            }
        }
    }, 0x0);
    _0x3a1dd0[_0xbec2('0x19')]();
}
function reset() {
    cylRot = 0x0;
    pinHealth = 0x64;
    pinRot = 0x0;
    pin[_0xbec2('0x12')]({
        'transform': 'rotateZ(' + pinRot + _0xbec2('0x8')
    });
    cyl[_0xbec2('0x12')]({
        'transform': _0xbec2('0x7') + cylRot + _0xbec2('0x8')
    });
    driver[_0xbec2('0x12')]({
        'transform': 'rotateZ(' + cylRot + _0xbec2('0x8')
    });
    TweenLite['to'](pin[_0xbec2('0x16')](_0xbec2('0x17')), 0x0, {
        'rotationZ': 0x0,
        'x': 0x0,
        'y': 0x0,
        'opacity': 0x1
    });
    TweenLite['to'](pin[_0xbec2('0x16')](_0xbec2('0x18')), 0x0, {
        'rotationZ': 0x0,
        'x': 0x0,
        'y': 0x0,
        'opacity': 0x1
    });
}
function outOfPins() {
    gameOver = !![];
	console.log("Game Over");
    $('#lose')[_0xbec2('0x12')](_0xbec2('0x1a'), _0xbec2('0x1b'));
    $(_0xbec2('0x1c'))[_0xbec2('0x1d')]();    
    mp.trigger("LockPickResult",0);
	
}
function unlock() {
	console.log("unlocked");
    gameOver = !![];
    $(_0xbec2('0x21'))[_0xbec2('0x12')]('display', _0xbec2('0x1b'));
    $(_0xbec2('0x1c'))[_0xbec2('0x1d')]();
	mp.trigger("LockPickResult",1);
	
}
Util = {};
Util[_0xbec2('0x6')] = function (_0x299282, _0x1559cd, _0xaf28ad) {
    return Math[_0xbec2('0x23')](Math[_0xbec2('0x24')](_0x299282, _0xaf28ad), _0x1559cd);
};
Util[_0xbec2('0x25')] = function (_0x1dc0c0, _0x2166ab, _0x1c8fe1, _0x44ef39, _0x41776f) {
    return (_0x1dc0c0 - _0x2166ab) * (_0x41776f - _0x44ef39) / (_0x1c8fe1 - _0x2166ab) + _0x44ef39;
};
