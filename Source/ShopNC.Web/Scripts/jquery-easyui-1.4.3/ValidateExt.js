$.extend($.fn.validatebox.defaults.rules, {
    alpha: {
        validator: function (value, param) {
            if (value) {
                return /^[a-zA-Z\u00A1-\uFFFF]*$/.test(value);
            } else {
                return true;
            }
        },
        message: '只能输入字母.'
    },
    alphanum: {
        validator: function (value, param) {
            if (value) {
                return /^([a-zA-Z\u00A1-\uFFFF0-9])*$/.test(value);
            } else {
                return true;
            }
        },
        message: '只能输入字母和数字.'
    },
    positive_int: {
        validator: function (value, param) {
            if (value) {
                return /^[0-9]*[1-9][0-9]*$/.test(value);
            } else {
                return true;
            }
        },
        message: '只能输入正整数.'
    },
    numeric: {
        validator: function (value, param) {
            if (value) {
                return /^[0-9]*(\.[0-9]+)?$/.test(value);
            } else {
                return true;
            }
        },
        message: '只能输入数字.'
    },
    chinese: {
        validator: function (value, param) {
            if (value) {
                return /[^\u4E00-\u9FA5]/g.test(value);
            } else {
                return true;
            }
        },
        message: '只能输入中文'
    },

    authNum:{
        validator: function (value, param) {
            if (value) {
                return /(^\d{15}$)|(^\d{18}$)|(^\d{17}(\d|X|x)$)/.test(value);
            } else {
                return true;
            }
        },
        message: '身份证输入有误！'
    }

});


$.extend({
    SetColorToRequired: function () {
        $(function () {
            var validate = $("input[required='required']");
            validate.after("<span style=color:red class='valrequired'>*</span>");
        });
    }
});

$.extend($.fn.validatebox.defaults.rules, {
    equals: {
        validator: function (value, param) {
            return value == $(param[0]).val();
        },
        message: 'Field do not match.'
    }
});


