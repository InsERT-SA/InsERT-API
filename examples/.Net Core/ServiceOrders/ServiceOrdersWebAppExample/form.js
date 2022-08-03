$.validator.setDefaults({ ignore: '' });

$(document).ready(function () {
    $('.radio_isCompany').on('click', function () {

        $('#ServiceRegistration_FirstName').valid();
        $('#ServiceRegistration_LastName').valid();
        $('#ServiceRegistration_CompanyName').valid();
        $('#ServiceRegistration_NIP').valid();
    });

    $(".consent-more").hide();
    $(".show_hide").on("click", function () {
        var txt = $(".consent-more").is(':visible') ? 'Rozwiń' : 'Zwiń';
        $(".show_hide").text(txt);
        $(this).next('.consent-more').slideToggle(200);
    });

    $('#ServiceRegistration_Consented').change(function () {
        $('#ServiceRegistration_Consented').valid();
    })
});

$.validator.addMethod("requireIf-IsCompany-False",
    function (value, element, parameters) {
        if (value.trim() == '' && !document.getElementById('client-company').checked) {
            return false;
        }

        return true;
    });

$.validator.addMethod("requireIf-IsCompany-True",
    function (value, element, parameters) {
        if (value.trim() == '' && document.getElementById('client-company').checked) {
            return false;
        }

        return true;
    });
$.validator.unobtrusive.adapters.addBool("mustBeTrue", "required");

$.validator.unobtrusive.adapters.add("requireIf-IsCompany-False", [], function (options) {
    options.rules["requireIf-IsCompany-False"] = {};
    options.messages["requireIf-IsCompany-False"] = options.message;
});

$.validator.unobtrusive.adapters.add("requireIf-IsCompany-True", [], function (options) {
    options.rules["requireIf-IsCompany-True"] = {};
    options.messages["requireIf-IsCompany-True"] = options.message;
});