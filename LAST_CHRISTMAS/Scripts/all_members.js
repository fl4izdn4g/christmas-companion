jQuery(function () {
    var code = [];

    jQuery('.band-element').on('click', function (e) {
        var currentState = jQuery(this).attr('data-state');
        var value = jQuery(this).attr('data-id');
            
        if (currentState == 'unchecked') {
            code.push(value);
            jQuery(this).attr('data-state', 'checked');
        }
        else {
            code.splice(code.indexOf(value), 1);
            jQuery(this).attr('data-state', 'unchecked');
        }

        var computedCode = code.join('');
        jQuery('#bandCodeValue').text(computedCode);
        checkCodes();        
    });

    jQuery('#giftCodeValue').on('change', function () {
        checkCodes();
    });

    jQuery('#santaCodeValue').on('change', function () {
        checkCodes();
    });

    function checkCodes() {
        var bandValue = jQuery('#bandCodeValue').text();
        var giftValue = jQuery('#giftCodeValue').val();
        var santaValue = jQuery('#santaCodeValue').val();

        jQuery.ajax(
            '/Secret/Status', {
                data: {
                    bandCode: bandValue, 
                    santaCode: santaValue,
                    giftCode: giftValue
                }
        }).success(function (data) {
            console.log(data);
            if (data.BandStatus == "OK") {
                jQuery('#bandLock').removeClass('glyphicon-lock locked').addClass('glyphicon-ok unlocked');
            }
            else {
                jQuery('#bandLock').removeClass('glyphicon-ok unlocked').addClass('glyphicon-lock locked');
            }

            if (data.GiftStatus == "OK") {
                jQuery('#giftLock').removeClass('glyphicon-lock locked').addClass('glyphicon-ok unlocked');
            }
            else {
                jQuery('#giftLock').removeClass('glyphicon-ok unlocked').addClass('glyphicon-lock locked');
            }

            if (data.SantaStatus == "OK") {
                jQuery('#santaLock').removeClass('glyphicon-lock locked').addClass('glyphicon-ok unlocked');
            }
            else {
                jQuery('#santaLock').removeClass('glyphicon-ok unlocked').addClass('glyphicon-lock locked');
            }

            if (data.SantaStatus == "OK" && data.GiftStatus == "OK" && data.BandStatus == "OK") {
                window.location.href = data.FinalLink;
            }


        });
    }

});