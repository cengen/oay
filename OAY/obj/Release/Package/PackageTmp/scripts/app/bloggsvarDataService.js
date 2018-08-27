var httpVerbs = {
    POST: "POST",
    PUT: "PUT",
    GET: "GET",
    DEL: "DELETE"
};

//client-side data-service that incapsulate all interaction with the web-api
//self-executable javascript som er tilgjengelig for alle filer
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
                return this.commit(httpVerbs.DEL, "/api/bloggsvar/" + data.bloggsvarId);
            },

            save: function (data) {                
                var
                    type = httpVerbs.POST,
                    url = "/api/bloggsvar";
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