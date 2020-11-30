$(function () {

    $.ajax({
        url: "api/data/Get-by-country",
        success: function (result) {

            var data;
            var myString = "{";
            for (var i = 0; i < result.length; i++) {
                var name = result[i].name;
                var count = result[i].count;

                myString = myString + '"' + name + '":"' + count + '",';
            }
            myString = myString + '"ZZ":"1"}';
            data = JSON.parse(myString);

            $('#world-map').vectorMap({
                map: 'world_mill',
                series: {
                    regions: [{
                        values: data,
                        scale: ['#C8EEFF', '#0071A4'],
                        normalizeFunction: 'polynomial'
                    }]
                },
                onRegionTipShow: function (e, el, code) {
                    el.html(el.html() + ' (Visitors - ' + data[code] + ')');
                }
            });

        }
    });

  

});