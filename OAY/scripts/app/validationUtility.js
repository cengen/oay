var ValidationUtility = function () {
        var
            validationElements = $("[data-role='validate']"),
            elementCount = 0;

        validationElements.popover({
            placement: "top"
        });

        validationElements.on("invalid", function () {
            if (elementCount === 0) {
                $("#" + this.id).popover("show");
                elementCount++;
            }
        });
        validationElements.on("blur", function () {
            $("#" + this.id).popover("hide");
        });

        var validate = function (formSelector) {
            elementCount = 0;

            if (formSelector.indexOf("#") === -1) {
                formSelector = "#" + formSelector;
            }

            return $(formSelector)[0].checkValidity();
        };

        return {
            validate: validate
        };
    };

$(function () {
    var validator = new ValidationUtility();

    $("[data-role='trigger-validation']").click(function () {
        if (validator.validate("battur-data-form")) {
            $("#msg").text("Valid");
        }
        else if (validator.validate("samarbeidspartner-data-form")) {
            $("#msg").text("Valid");
        }
        else if (validator.validate("kommentar-data-form")) {
            $("#msg").text("Valid");
        }
        else if (validator.validate("bloggpost-data-form")) {
            $("#msg").text("Valid");
        }
        else if (validator.validate("hvaskjer-data-form")) {
            $("#msg").text("Valid");
        }
        else if (validator.validate("meny-data-form")) {
            $("#msg").text("Valid");
        }
        else {
            $("#msg").text("Invalid");
        }
    });
});
