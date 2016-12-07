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

        jQuery('#codeValue').text(code.join(''));
        console.log(code);
    });
});