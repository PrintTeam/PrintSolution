$(function () {
    var selectItem = $("#selectStatus option:selected").val();

    if (selectItem !== "EL") {
        $('#panelLeave').hide();
    } else {
        $('#panelLeave').show();
    }

    $('#btnLeaveDate').click(function () {
        $('#txtLeaveDate').datepicker({
            dateFormat: 'yy-mm-dd'
        });
        $('#txtLeaveDate').datepicker("show");

    });

    $('#selectStatus').change(function () {
        if ($(this).val() !== "EL") {
            $('#panelLeave').hide();
        } else {
            $('#panelLeave').show();
        }
    });
});

