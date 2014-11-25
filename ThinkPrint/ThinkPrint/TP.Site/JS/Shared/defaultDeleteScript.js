$(document).ready(function () {
    $('.table-action button').click(function () {
        
        var deleteId = this.id;
     
        var hrefValue=this.form.action+"/Delete/" + deleteId + "";
        $('#btnDelete').attr("href", hrefValue);
        $('#myModal').modal('show');
    });
});