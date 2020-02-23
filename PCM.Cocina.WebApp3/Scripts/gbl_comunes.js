function paintErrorStateAttr() {
    $('.validation-summary-errors').each(function () {
        $(this).addClass('alert');
        $(this).addClass('alert-danger');
    });

    $('form').each(function () {
        $(this).find('div.form-group').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('has-error');
                $(this).find('span.field-validation-error').
                   removeClass('field-validation-error');
            }
        });
    });
    $('form').each(function () {
        $(this).find('div.input-group').each(function () {
            if ($(this).find('span.field-validation-error').length > 0) {
                $(this).addClass('has-error');
                $(this).find('span.field-validation-error').
                   removeClass('field-validation-error');
            }
        });
    });
    $('[data-valmsg-replace="true"]').hide();
    $('input[type="text"]').on('input', function (evt) {
        $(this).val(function (_, val) {
            return val.toUpperCase();
        });
    });
}

function SetUpDateTimePicker() {
    $('[data-bs-dt-picker="true"]').datetimepicker({ format: "DD/MM/YYYY" })
}

function SetUpCurrencyFormatInput() {
    $('[data-currency-input="true"]').autoNumeric('init').addClass("text-right").trigger('focusout');
}

function GenerateAlert(cssClass, message) {
    return '<div class="alert alert-' + cssClass + '"><button type="button" class="close" data-dismiss="alert"><i class="fa fa-times"></i></button><strong>' + message + '</strong></div>';
}
(function () {
    var codigo = $('#CodigoContratanteSiniestro').val();
    if (codigo == "0") {
        $("#btnVincularCertificadoCrear").prop('disabled', true);

    }
    else {
        $("#btnVincularCertificadoCrear").prop("disabled", false);

    }
});
(function () {
    var codigo2 = $('#CodigoContratanteSiniestro').val();
    if (codigo2 == "0") {
        $("#btnVincularCertificado").prop('disabled', true);

    }
    else {
        $("#btnVincularCertificado").prop("disabled", false);

    }
});

function getContainerId(containerObjectOrId) {
    var processedId = "";
    if ((containerObjectOrId instanceof jQuery) == true) {
        console.debug('Is a jQuery Object');
        processedId = "#" + containerObjectOrId.attr("id")
    }
    else {
        console.debug('Is not a jQuery Object');
        processedId = containerObjectOrId;
    }
    console.info('Processed id is ' + processedId)
    return processedId;
}

var dataTabla = {};

var GetZonasGeograficas = function () {
    var requestValue = $(this).val();
    var target = $(this).data('selector-target');
    $.getJSON("/ZonaGeografica/GetZonaGeografica?code=" + requestValue, function (data) {
        var items = [];
        //items.push("<option value='' >Seleccione Uno</option>");
        $($(target).data('selector-target')).empty();
        $.each(data, function (key, value) {
            items.push("<option value='" + value.NombreTipoCorto + "'>" + value.NombreTipo + "</option>");
        });

        $(target).html(items.join(""));
        $(target).trigger("chosen:updated");
    });
}

var GetTodosLosDocumentos = function () {
    var requestValue = $('#CodigoSiniestro').val();
    var target = $(this).data('selector-target');
    $.getJSON("/DocumentoRiesgo/GetListadoDeDocumentos?code=" + requestValue, function (data) {
        var items = [];
        $($(target).data('selector-target')).empty();
        $.each(data, function (key, value) {
            items.push("<option value='" + value.NombreEstado + "'>" + value.NombreEstadoCorto + "</option>");
        });

        $(target).html(items.join(""));
        $(target).trigger("chosen:updated");
    });
}

var LoadDetailsTableWithSuccessCallback = function (elem, successcallback) {
    $(elem).load($(elem).data('load-url'), function (response, status, xhr) {
        if (status == "error") {
            var msg = '<div class="alert alert-info text-center" role="alert"><strong><i class="fa  fa-exclamation-circle"></i> No se encontraron items en la lista</strong></div>';
            $(elem).empty();
            $(elem).append(msg);
        } else {
            dataTabla = $($(elem).data('table-target')).dataTable(optionsDatatable);
            successcallback();
            //$($(elem).data('table-target') + ' tbody').on('click', 'tr', LoadSelfForm);
        }
    });
}

var LoadDetailsTable = function (elem) {
    $(elem).load($(elem).data('load-url'), function (response, status, xhr) {
        if (status == "error") {
            var msg = '<div class="alert alert-info text-center" role="alert"><strong><i class="fa  fa-exclamation-circle"></i> No se encontraron items en la lista</strong></div>';
            $(elem).empty();
            $(elem).append(msg);
        } else {
            dataTabla = $($(elem).data('table-target'))
                 .dataTable(optionsDatatable);
            $($(elem).data('table-target') + ' tbody').on('click', 'tr', LoadSelfForm);
        }
    });
}
var LoadDetailsTableWithCallback = function (elem, callback) {
    $(elem).load($(elem).data('load-url'), function (response, status, xhr) {
        if (status == "error") {
            var msg = '<div class="alert alert-info text-center" role="alert"><strong><i class="fa  fa-exclamation-circle"></i> No se encontraron items en la lista</strong></div>';
            $(elem).empty();
            $(elem).append(msg);
        } else {
            dataTabla = $($(elem).data('table-target'))
                 .dataTable(optionsDatatable);
            $($(elem).data('table-target') + ' tbody').on('click', 'tr', null, function () {
                var $rowContext = $(this);
                LoadSelfForWithCallback($rowContext, callback)
            });
        }
    });
}

function verificarSiEsAutoNumeric(elem) {
    var entrada = elem + " input";
    var result = 0;
    result = $(entrada).filter(function (e, item) { return $(item).data("autoNumeric") != undefined; }).length;
    return result;
}

var changeDeleteButtonForm = function (elem) {
    //$(elem).click(function () {
    $(elem).off('click').on('click', function () {
        var target = $(this).data('div-target');
        var listName = $(this).data('name-list');
        var buttonCan = $(this).data('button-cancel');
        var buttonNew = $(this).data('button-new');
        var actionUrl = $(this).data('action');
        var methodUrl = $(this).data('method');
        var newFormOk = $(this).data("new-form-ok");
        var newFormError = $(this).data("new-form-error");
        var idModelCle = $(this).data("id-clean");

        $.ajax({ url: actionUrl, method: methodUrl })
            .done(function (data) {
                $(target).empty();
                $(target).append(data);
                $(buttonCan).unbind();
                $(buttonCan).click(function () { $(buttonNew).click(); return false; });
                changeDeleteButtonForm(getContainerId(elem));
                var aVal = $(idModelCle).val();
                if (aVal == 1) {
                    LoadDetailsTable($(listName));
                }
                console.log("Valor aVal " + aVal);
                changeSubmitDetailForm(aVal == 1 ? newFormOk : newFormError);
                SetUpDateTimePicker();
                SetUpCurrencyFormatInput();
            });
    });
}

var changeDeleteButtonFormWithCallBack = function (elem, callBack) {
    //$(elem).click(function () {
    $(elem).off('click').on('click', function () {
        var target = $(this).data('div-target');
        var listName = $(this).data('name-list');
        var buttonCan = $(this).data('button-cancel');
        var buttonNew = $(this).data('button-new');
        var actionUrl = $(this).data('action');
        var methodUrl = $(this).data('method');
        var newFormOk = $(this).data("new-form-ok");
        var newFormError = $(this).data("new-form-error");
        var idModelCle = $(this).data("id-clean");

        $.ajax({ url: actionUrl, method: methodUrl })
            .done(function (data) {
                $(target).empty();
                $(target).append(data);
                $(buttonCan).unbind();
                $(buttonCan).click(function () { $(buttonNew).click(); return false; });
                changeDeleteButtonFormWithCallBack(getContainerId(elem), callBack);
                var aVal = $(idModelCle).val();
                if (aVal == 1) {
                    LoadDetailsTable($(listName), callBack);
                }
                console.log("Valor aVal " + aVal);
                changeSubmitDetailFormWithCallBack(aVal == 1 ? newFormOk : newFormError, callBack);
                SetUpDateTimePicker();
                SetUpCurrencyFormatInput();
            });
    });
}

var changeSubmitDetailForm = function (elem) {
    //$(elem).submit(function (e) {
    $(elem).off('submit').on('submit', function (e) {
        e.preventDefault();
        var target = $(this).data('div-target');
        var listName = $(this).data('name-list');
        var buttonCan = $(this).data("button-cancel");
        var buttonNew = $(this).data("button-new");
        var buttonDele = $(this).data("button-delete");
        //var tagLimpiar = $(this).data("created-clean");
        var idModelCle = $(this).data("id-clean");
        var nomShowDiv = $(this).data("div-show");
        var newForm = $(this).data("new-form");
        var form = "#" + $(this).attr("id");
        $.ajax({
            url: $(this).attr('action')
            , method: $(this).attr('method')
            , data: verificarSiEsAutoNumeric(form) > 0 ? $(this).autoNumeric("getString") : $(this).serialize()
        })
        .done(function (data) {
            $(target).empty();
            $(target).append(data);
            $(buttonCan).unbind();
            $(buttonCan).click(function () { $(buttonNew).click(); return false; });
            paintErrorStateAttr();
            var aVal = $(idModelCle).val();
            console.log("Valor aVal " + aVal);
            changeSubmitDetailForm(aVal == 1 ? newForm : getContainerId(elem));
            if (aVal == 1) {
                LoadDetailsTable(listName);
            }
            changeDeleteButtonForm($(buttonDele));
            SetUpDateTimePicker();
            //limpiarTest(tagLimpiar, idModelCle);
            SetUpCurrencyFormatInput();
        });
    });
}


var changeSubmitDetailFormWithCallBack = function (elem, callBack) {
    //$(elem).submit(function (e) {
    $(elem).off('submit').on('submit', function (e) {
        e.preventDefault();
        var target = $(this).data('div-target');
        var listName = $(this).data('name-list');
        var buttonCan = $(this).data("button-cancel");
        var buttonNew = $(this).data("button-new");
        var buttonDele = $(this).data("button-delete");
        //var tagLimpiar = $(this).data("created-clean");
        var idModelCle = $(this).data("id-clean");
        var nomShowDiv = $(this).data("div-show");
        var newForm = $(this).data("new-form");
        var form = "#" + $(this).attr("id");
        $.ajax({
            url: $(this).attr('action')
            , method: $(this).attr('method')
            , data: verificarSiEsAutoNumeric(form) > 0 ? $(this).autoNumeric("getString") : $(this).serialize()
        })
        .done(function (data) {
            $(target).empty();
            $(target).append(data);

            callBack($(target), function () {
                $(buttonCan).unbind();
                $(buttonCan).click(function () { $(buttonNew).click(); return false; });
                paintErrorStateAttr();
                var aVal = $(idModelCle).val();
                console.log("Valor aVal " + aVal);
                changeSubmitDetailFormWithCallBack(aVal == 1 ? newForm : getContainerId(elem));
                if (aVal == 1) {
                    LoadDetailsTableWithCallback(listName, callBack);
                }
                changeDeleteButtonFormWithCallBack($(buttonDele), callBack);
                SetUpDateTimePicker();
                //limpiarTest(tagLimpiar, idModelCle);
                SetUpCurrencyFormatInput();
            });


        });
    });
}

function limpiarTest(nom, idModelVal) {
    var a = $(idModelVal).val();
    if (typeof nom != 'undefined' && a == 1) {
        $(nom + '-combo').val("0");
        $(nom).val("");
        $(nom + '-combo-tip').val("000");
        $(nom + '-combo-tip-2').val("");
    }
}
$(function () {
    SetUpDateTimePicker();

    $('.fecSAPRO').datetimepicker({ format: 'DD/MM/YYYY' });
    $('.btnCanSAPRO').unbind();
    $('.btnCanSAPRO').click(LoadSelfForm);
    paintErrorStateAttr();
    SetUpCurrencyFormatInput();
})

var optionsDatatable = {
    bFilter: false,
    bInfo: false,
    paging: false,
    "scrollY": "300px",
    "scrollCollapse": true,
    "bAutoWidth": false,
    "language": {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    }
}

var changeToSimpleSubmitForm = function (elem) {
    //$(elem).submit(function (e) {
    $(elem).off('submit').on('submit', function (e) {
        e.preventDefault();
        var formobj = $(elem);
        var target = $(elem).data('replace-target');
        $.ajax({
            url: formobj.attr('action'),
            data: verificarSiEsAutoNumeric(formobj) > 0 ? $(this).autoNumeric("getString") : $(this).serialize(),
            method: formobj.attr('method')
        }).done(function (data) {
            $(target).empty();
            $(target).append(data);
            paintErrorStateAttr();
            SetUpCurrencyFormatInput();
            changeToSimpleSubmitForm(getContainerId(elem));
        });
    });
}
var changeSubmitForm = function (elem) {
    var btn = $(elem).find('form').data("btn-sub");
    //$(btn).click(function (e) {
    $(btn).off('click').on('click', function (e) {
        e.preventDefault();
        var formobj = $(this).data('form-name');
        $.ajax({
            url: $(formobj).data('action'),
            data: verificarSiEsAutoNumeric(formobj) > 0 ? $(this).autoNumeric("getString") : $(this).serialize(),
            method: $(formobj).data('method')
        }).done(function (data) {
            $(formobj).replaceWith(data);
            SetUpCurrencyFormatInput();
        });
    });
}

var LoadForm = function (elem) {
    var obj = $(elem);
    var target = obj.data('load-target');
    $(target).load(obj.data('load-entry-target'));
}

var LoadSelfForm = function () {
    var obj = $(this);
    var target = obj.data('load-target');
    $(target).load(obj.data('load-entry-target'), function () {
        $('.fecSAPRO').datetimepicker({ format: 'DD/MM/YYYY' });
        var buttonCan = obj.data("button-cancel");
        var buttonNew = obj.data("button-new");
        var buttonDele = obj.data("button-delete");
        var nomShowDiv = obj.data("div-show");
        $(buttonCan).unbind();
        $(buttonCan).click(function () { $(buttonNew).click(); return false; });
        var targetEdit = obj.data('edit-target');
        SetUpCurrencyFormatInput();
        changeSubmitDetailForm(targetEdit);
        changeDeleteButtonForm(buttonDele);
        SetUpDateTimePicker();
    });
}

var LoadSelfForWithCallback = function (rowCallback, callback) {
    var obj = rowCallback;
    var target = obj.data('load-target');
    $(target).load(obj.data('load-entry-target'), function () {

        $('.fecSAPRO').datetimepicker({ format: 'DD/MM/YYYY' });
        var buttonCan = obj.data("button-cancel");
        var buttonNew = obj.data("button-new");
        var buttonDele = obj.data("button-delete");
        var nomShowDiv = obj.data("div-show");
        $(buttonCan).unbind();
        $(buttonCan).click(function () { $(buttonNew).click(); return false; });
        var targetEdit = obj.data('edit-target');
        SetUpCurrencyFormatInput();
        changeSubmitDetailFormWithCallBack(targetEdit, callback);
        changeDeleteButtonFormWithCallBack(buttonDele, callback);
        //SetUpDateTimePicker();   
    });
}


