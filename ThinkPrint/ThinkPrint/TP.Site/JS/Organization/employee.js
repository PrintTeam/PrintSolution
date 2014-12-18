$(function () {
    $('#btnEntryDate').click(function () {
        $('#txtEntryDate').datepicker({
            dateFormat: 'yy-mm-dd'
        });
        $('#txtEntryDate').datepicker("show");
    });
});