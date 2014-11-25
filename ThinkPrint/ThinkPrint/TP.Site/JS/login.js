
$(function () {
    $('.login-page').backstretch("../img/2.jpg", { fade: 500 });
  

});

var validateLogin = function () {
    return {
        init: function () {
            $("#loginPanel").validate({
                errorClass: "help-block animation-slideUp",
                errorElement: "div",
                errorPlacement: function (error, element) {
                    element.parents(".form-group > div").append(error)
                },
                highlight: function (error) {
                    $(error).closest(".form-group").removeClass("has-error").addClass("has-error"),
                    $(error).closest(".help-block").remove()
                },
                success: function (error) {
                    error.closest(".form-group").removeClass("has-error"),
                    error.closest(".help-block").remove()
                },
                rules: {
                    "UserName": { required: !0},
                    "Password": { required: !0, minlength: 5}
                },
                messages: {
                    "UserName": "请输入用户名称",
                    "Password": {
                        required: "请输入登录密码", minlength: "请输入5位以上的登录密码"
                    }
                }
            });
        }
    };
}();