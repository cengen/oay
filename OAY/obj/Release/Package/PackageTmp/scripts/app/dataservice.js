var _mixIns = (function () {
    _.mixin({
        numberWithCommas: function (value) {
            return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
        }
    });
});
var httpVerbs = {
    POST: "POST",
    PUT: "PUT",
    GET: "GET",
    DEL: "DELETE"
};

//client-sIde data-service that incapsulate all interaction with the web-api
//self-executable javascript som er tilgjengelig for alle filer
var batturerDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["batturId"];
                }

                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json",
                    error: function (xhr) {
                        alert(xhr);
                    }
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/batturerapi/" + data.batturId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/batturerapi";

                if (data.batturId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.batturId;
                }
                return this.commit(type, url, data);
            },


            //asynkront laste opp bilde til mvc-controller
            saveImage: function (data) {
                return $.ajax({
                    type: httpVerbs.POST,
                    url: "/batturerapi/lastoppbilde",
                    processData: false,
                    contentType: false,
                    traditional: true,
                    async: false,
                    success: function (response) {
                        return response;
                    },
                    data: data
                });
            },

            deleteImage: function (data) {
                return $.ajax({
                    type: httpVerbs.DEL,
                    url: "/batturerapi/slettbilde",
                    data: data
                });
            }

        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del,
        saveImage: ds.saveImage,
        deleteImage: ds.deleteImage
    }

})();

var batturimagesDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["imageId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/batturimagesapi/" + data.imageId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/batturimagesapi";

                if (data.imageId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.imageId;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();

var batturKategorierDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["BatturKategoriId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                async: false;
                return this.commit(httpVerbs.DEL, "/api/batturkategorierapi/" + data.BatturKategoriId);
            },


            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/batturkategorierapi";

                if (data.batturkategoriId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.batturkategoriId;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var bloggimagesDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["imageId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/bloggimagesapi/" + data.imageId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/bloggimagesapi";

                if (data.imageId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.imageId;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var bloggpostDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["bloggpostId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/bloggpostapi/" + data.bloggpostId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/bloggpostapi";

                if (data.bloggpostId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.bloggpostId;
                }
                return this.commit(type, url, data);
            },

            //asynkront laste opp bilde til mvc-controller
            saveImage: function (data) {
                return $.ajax({
                    type: httpVerbs.POST,
                    url: "/bloggpostapi/lastoppbilde",
                    processData: false,
                    contentType: false,
                    traditional: true,
                    async: false,
                    success: function (response) {
                        return response;
                    },
                    data: data
                });
            },

            deleteImage: function (data) {
                return $.ajax({
                    type: httpVerbs.DEL,
                    url: "/bloggpostapi/slettbilde",
                    data: data
                });
            }


        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del,
        saveImage: ds.saveImage,
        deleteImage: ds.deleteImage
    }

})();
var bloggsvarDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["bloggsvarId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/bloggsvarapi/" + data.bloggsvarId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/bloggsvarapi";
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var hvaskjerDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {

                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["hvaskjerId"];
                }

                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/hvaskjerapi/" + data.hvaSkjerId);
            },

            save: function (data) {

                var
                    type = httpVerbs.POST,
                    url = "/api/hvaskjerapi";
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var menyDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["menyId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/menyapi/" + data.menyId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/menyapi";

                if (data.menyId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.menyId;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var bildegalleriDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["bildegalleriId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/bildegalleriapi/" + data.bildegalleriId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/bildegalleriapi";

                if (data.bildegalleriId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.bildegalleriId;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var prisinfoDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["prisinfoid"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/prisinfoapi/" + data.prisinfoid);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/prisinfoapi";

                if (data.prisinfoid > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.prisinfoid;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
var samarbeidspartnereDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["samarbeidspartnerId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/samarbeidspartnereapi/" + data.samarbeidspartnerId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/samarbeidspartnereapi";

                if (data.samarbeidspartnerId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.samarbeidspartnerId;
                }
                return this.commit(type, url, data);
            },

            //asynkront laste opp bilde til mvc-controller
            saveImage: function (data) {
                return $.ajax({
                    type: httpVerbs.POST,
                    url: "/samarbeidspartnereapi/lastoppbilde",
                    processData: false,
                    contentType: false,
                    traditional: true,
                    async: false,
                    success: function (response) {
                        return response;
                    },
                    data: data
                });
            },

            deleteImage: function (data) {
                return $.ajax({
                    type: httpVerbs.DEL,
                    url: "/samarbeidspartnereapi/slettbilde",
                    data: data
                });
            }


        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del,
        saveImage: ds.saveImage,
        deleteImage: ds.deleteImage
    }

})();
var samarbeidspartnerimagesDataService = (function () {

    var
        ds = {
            //send a request to the server
            commit: function (type, url, data) {
                //Remove "id" memeber to prepare for INSERT
                if (type === httpVerbs.POST) {
                    delete data["samarbeidspartnerimageId"];
                }
                return $.ajax({
                    type: type,
                    url: url,
                    data: data,
                    dataType: "json"
                });
            },

            del: function (data) {
                return this.commit(httpVerbs.DEL, "/api/samarbeidspartnerimagesapi/" + data.samarbeidspartnerimageId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/samarbeidspartnerimagesapi";
                if (data.samarbeidspartnerimageId > 0) {
                    type = httpVerbs.PUT;
                    url += "/" + data.samarbeidspartnerimageId;
                }
                return this.commit(type, url, data);
            }
        };

    //for å være sikker på at this blir brukt(handled) riktig i appen
    //peker tilbake til ds objektet
    _.bindAll(ds, "del", "save");

    //peker til interne metoder som kalles når f.ex batturerDataService.save brukes
    return {
        save: ds.save,
        del: ds.del
    }

})();
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

