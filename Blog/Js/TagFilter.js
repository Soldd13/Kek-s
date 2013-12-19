$(document).ready(function ()

{
    $('.CommMess').blur(function () {
        var s = $(this).val();
        s = s.replace(/<\/?[^>]+>/g, "");
        s = s.replace(/<|>/g, "");
        $(this).val(s);
    });
    $('.CommName').blur(function () {
        var s = $(this).val();
        s = s.replace(/<\/?[^>]+>/g, "");
        s = s.replace(/<|>/g, "");
        $(this).val(s);
    });
});