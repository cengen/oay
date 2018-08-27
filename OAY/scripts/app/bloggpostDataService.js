var httpVerbs = {
    POST: "POST",
    PUT: "PUT",
    GET: "GET",
    DEL: "DELETE"
};

//client-side data-service that incapsulate all interaction with the web-api
//self-executable javascript som er tilgjengelig for alle filer
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
                return this.commit(httpVerbs.DEL, "/api/bloggpost/" + data.bloggpostId);
            },

            save: function (data) {
                var
                    type = httpVerbs.POST,
                    url = "/api/bloggpost";

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
                    url: "/bloggpost/lastoppbilde",
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
                    url: "/bloggpost/slettbilde",
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
