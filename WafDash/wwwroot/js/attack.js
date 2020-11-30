$(function () {
    $.ajax({
        url: "api/data/Get-by-attack",
        success: function (result) {
            var div = "<div>";
            for (var i = 0; i < result.length; i++) {
                var name = result[i].name;
                var count = result[i].count;

                var line = "";
                line = line + '<div><span style="float:left;"><p style="padding-left: 5px;">' + name + '</p></span><span style="float:right; padding: 0, 3px, 0, 0;""><p style="padding-right: 5px;">' + count + '</p></span></div><div style="clear:both;"></div>';
                div = div + line;
            }
            $("#TopAttacks").html(div);
        }
    });
});