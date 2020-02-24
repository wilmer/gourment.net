$(document).ready(function () {
    $("#txtNombreHuesped").focus();
    $("#FechaInicioFiltro").datetimepicker({ format: "DD/MM/YYYY" });
    $("#FechaInicioFiltro").datetimepicker({ format: "DD/MM/YYYY" });
});

$(document).on("click", "#btnloadNacionalidades", null, function () {
    $('#modal-nacionalidad').modal('show');
});

$(document).on("click", "#btnAgregar", null, function () {
   
        $('#modal-dori-ok').html('<span class="fa fa-pencil"></span>&nbsp;Agregar');
        $('#myModalLabel').text("REGISTRAR UN MENÚ");
        $.ajax({ url: "Menu/RegistrarMenu", type: 'get' }).done(function (data) {
            $("#modal-huesped-body").html("");

            $("#modal-huesped-body").html(data);
            $("#modal-huesped").modal('toggle');
            //$("#FechaIngreso").datetimepicker({ format: "DD/MM/YYYY" });
            //$("#FechaSalida").datetimepicker({ format: "DD/MM/YYYY" });
            //$('#ImporteHabitacion').autoNumeric('').addClass("text-right").trigger('focusout');
            //$("#modal-huesped input").first().focus();
            //$("#sel-docu").filter('[autofocus]').trigger('chosen:activate');
            //$(".chosen-container").first().find('input').val("");

        });

 
});


$(document).on("click", "#modal-nacionalidad-ok", null, function () {
    var descriPais = $('#txtNacionalidadAgregar').val();
    $.post('Huespedes/AgregarNacionalidad', {
        descriNacionalidad: descriPais
        }, function (data) {
            if (data.Result == "OK") {
                //$("#messagePanel").ccsaNotificationError("Se agrego ");
                $('#modal-nacionalidad').modal('hide');
            }
            else {
                //$("#messageResultadoEmitirFactura").ccsaNotificationError("No se emitio correctamente");
            }
        }).fail(function () {
            //$("#messageResultadoEmitirFactura").ccsaNotificationError("No se emitio correctamente");
        }).complete(function () {

        });
  
});

$.fn.extend({
    ccsaNotificationInformation: function (messageText) {
        var $divForMessage = $(this);
        $divForMessage.load("Templates/MessageNotificationSample.html", function () {
            var $messagePointer = $(this);
            $messagePointer.find("span").text(messageText);
            $messagePointer.fadeIn(300, function () { $messagePointer.fadeOut(300, function () { $messagePointer.fadeIn(300) }) });
        });
    },
    ccsaNotificationError: function (messageText) {
        var $divForMessage = $(this);
        $divForMessage.load("Templates/MessageErrorSample.html", function () {
            var $messagePointer = $(this);
            $messagePointer.find("span").text(messageText);
            $messagePointer.fadeIn(300, function () { $messagePointer.fadeOut(300, function () { $messagePointer.fadeIn(300) }) });
        });
    },
    ccsaNotificacionSuccess: function (messageText) {
        var $divForMessage = $(this);
        $divForMessage.load("Templates/MessageSuccessSample.html", function () {
            var $messagePointer = $(this);
            $messagePointer.find("span").text(messageText);
            $messagePointer.fadeIn(300, function () { $messagePointer.fadeOut(300, function () { $messagePointer.fadeIn(300) }) });
        });
    }
});

$(document).on("click", "#modal-dori-ok", null, function () {
    var nombreBoton = $('#modal-dori-ok').text().trim();
    if (nombreBoton === "Agregar") {
        $.post('Menu/CrearMenu', {
            nombreMenu: $('#DescripcionMenu').val(),
            cbEntrada1: $('#cbEntrada1').val(),
            cbEntrada2: $('#cbEntrada2').val(),
            cbPlatoDeFondo1: $('#cbPlatoDeFondo1').val(),
            cbPlatoDeFondo2: $('#cbPlatoDeFondo2').val(),
            cbRefresco: $('#cbRefresco').val()
          
        }, function (data) {
            if (data.Result == "OK") {

                $('#modal-huesped').modal('hide');
                $("#huesped-alert").ccsaNotificacionSuccess("Se agrego un huésped");
                sinisterNamespace.CargarTablaPolizas($("#txtNombre").val());
            }
            else {
                $("#huesped-alert").ccsaNotificationError("No se agrego un huésped");
               
            }
        }).fail(function () {
            $("#huesped-alert").ccsaNotificationError("No se emitio correctamente");
        }).complete(function () {

        });
    }
    else if (nombreBoton === "Modificar")
    {
        $.post('Huespedes/UpdateHuesped', {
            CodigoHuesped:$('#CodigoRegistroHuespedes').val(),
            NombreHuesped: $('#txtNombreDeHuesped').val(),
            CodigoGenero: $('#cbTipoGenero').val(),
            CodigoPais: $('#cbNacionalidad').val(),
            CodigoDocumento: $('#cbCodigoDocumento').val(),
            NumeroDocumento: $('#txtNumeroDocumento').val(),
            FechaInicio: $('#FechaIngreso').val(),
            FechaFin: $('#FechaSalida').val(),
            NumeroHabitacion: $('#NumeroHabitacion').val(),
            Tarifa: $('#ImporteHabitacion').val(),
            CodigoMoneda: $('#cbTipoMoneda').val()
        }, function (data) {
            if (data.Result == "OK") {

                $('#modal-huesped').modal('hide');
                $("#huesped-alert").ccsaNotificacionSuccess("Se modifico un huésped correctamente");
                sinisterNamespace.CargarTablaPolizas($("#txtNombreHuesped").val());
            }
            else {
                $("#huesped-alert").ccsaNotificationError("No se modifico un huésped");

            }
        }).fail(function () {
            $("#huesped-alert").ccsaNotificationError("No se emitio correctamente");
        }).complete(function () {

        });
    }

});

$(document).on("click", "#modal-dori-edit-ok", null, function () {

    $.post('Huespedes/UpdateHuesped', {
        CodigoHuesped:$('#CodigoRegistroHuespedes').val(),
        NombreHuesped: $('#txtNombreDeHuesped').val(),
        CodigoGenero: $('#cbTipoGenero').val(),
        CodigoPais: $('#cbNacionalidad').val(),
        CodigoDocumento: $('#cbCodigoDocumento').val(),
        NumeroDocumento: $('#txtNumeroDocumento').val(),
        FechaInicio: $('#FechaIngreso').val(),
        FechaFin: $('#FechaSalida').val(),
        NumeroHabitacion: $('#NumeroHabitacion').val(),
        Tarifa: $('#ImporteHabitacion').val(),
        CodigoMoneda: $('#cbTipoMoneda').val()
    }, function (data) {
        if (data.Result == "OK") {

            $('#modal-huesped').modal('hide');
            $("#huesped-alert").ccsaNotificacionSuccess("Se modifico correctamente");
            sinisterNamespace.CargarTablaPolizas($("#txtNombreHuesped").val());
        }
        else {
            $("#huesped-alert").ccsaNotificationError("No se agrego un huésped");
            //$("#messageResultadoEmitirFactura").ccsaNotificationError("No se emitio correctamente");
        }
    }).fail(function () {
        $("#huesped-alert").ccsaNotificationError("No se emitio correctamente");
    }).complete(function () {

    });

});

$(document).on("click", "#modal-dori-elim-ok", null, function () {

    $.post('Huespedes/EliminarHuesped', {
        CodigoHuesped:  $('#idHuespedEliminar').val()  
    }, function (data) {
        if (data.Result == "OK") {

            $('#modal-huesped-eliminar').modal('hide');
            $("#huesped-alert").ccsaNotificacionSuccess("Se eliminó correctamente");
            sinisterNamespace.CargarTablaPolizas($("#txtNombreHuesped").val());
        }
        else {
            $("#huesped-alert").ccsaNotificationError("No se elimino un huésped");
            //$("#messageResultadoEmitirFactura").ccsaNotificationError("No se emitio correctamente");
        }
    }).fail(function () {
        $("#huesped-alert").ccsaNotificationError("No se eliminó correctamente");
    }).complete(function () {

    });

});

function editarHuesped(id) {
    $('#modal-dori-ok').html('<span class="fa fa-pencil"></span>&nbsp;Modificar');

    $.ajax({ url: "Huespedes/EditarHuesped?CodigoRegistroHuespedes="+id, type: 'get' }).done(function (data) {
        $("#modal-huesped-body").html("");
        $('#myModalLabel').text("EDITAR UN HUÉSPED");
        $("#modal-huesped-body").html(data);
        $("#modal-huesped").modal('toggle');
        $("#FechaIngreso").datetimepicker({ format: "DD/MM/YYYY" });
        $("#FechaSalida").datetimepicker({ format: "DD/MM/YYYY" });
        $('#ImporteHabitacion').autoNumeric('').addClass("text-right").trigger('focusout');
        $("#modal-huesped input").first().focus();
        //$("#sel-docu").filter('[autofocus]').trigger('chosen:activate');
        //$(".chosen-container").first().find('input').val("");

    });
}

function eliminarHuesped(id) {
    $('#modal-huesped-eliminar').modal('show');
    $('#idHuespedEliminar').val(id);
}


(function (sinisterNamespace, $, undefined) {

    var polizasTable = "#tabledatapolizas";
    //var siniestrosTable = "#tabladatossiniestros";

    sinisterNamespace.CargarTablaPolizas = function (texto) {
        $(polizasTable).jtable('load', {
            texto: $("txt#NombreHuesped").val(),
            fechaInicio: $("#FechaInicioFiltro").val(),
            fechaFinal: $("#FechaFinFiltro").val(),
            CodigoTipoDocumento: $('#cbTipoDocumentoReporte').val(),
            CodigoPais: $('#cbTipoNacionalidadReporte').val()
        });
    };
    $(function () {
        $(polizasTable).jtable({
            messages: { noDataAvailable: 'No se encontraron Huéspedes' },
            title: 'Listado de Menus',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: 'Menu/ListarMenus'
            },
            fields: {
                ROW: { title: 'N°', width: '3%', edit: false, },
                DescripcionMenu: { title: 'Menu', width: '1%', list: false, edit: false },
                DescriEntrada1: { title: 'Entrada 1', width: '32%' },
                DescriEntrada2: { title: 'Entrada 2', width: '5%' },
                DescriPlatoDeFondo1: { title: 'Plato de fondo 1', width: '7%' },
                DescriPlatoDeFondo2: { title: 'Plato de fondo 2', width: '14%' },
                DescriRefresco: { title: 'Refresco', width: '7%' },
                /*
                Editar: {
        
                    display: function (data) {
                        return '<a class="btn btn-default" id="btnEditarHuesped"  onclick="editarHuesped('+data.record.CodigoRegistroHuespedes+')" ' + '"> <i class="fa fa-edit"></i> </a>';
                    }
                },
                Eliminar: {
                    display: function (data) {
                        return '<a class="btn btn-default" onclick="eliminarHuesped('+ data.record.CodigoRegistroHuespedes+ ')"> <i class="fa fa-trash"></i> </a> ';
                    }
                }
                 */
            }
        });

  

        sinisterNamespace.CargarTablaPolizas($("#txtNombre").val());
        $(polizasTable + " table thead tr").css("background-color", "#454545").css("color", "white").css("font-weight", 300);
        //$(siniestrosTable + " table thead tr").css("background-color", "#454545").css("color", "white").css("font-weight", 300);

        $("#btnLimpiar").click(function () {
            //$("#ClientChkId").prop('checked', true);
            $("#txtNombre").val("");
          
        });

        $("#btnBuscar").click(function () {
            
            $(polizasTable).jtable('load', { texto: $("#txtNombre").val()
                
            });
        });

        $(document).on("click", "#btnReporte", null, function () {
            if ($('#FechaInicioFiltro').val()=="" && $('#FechaFinFiltro').val()==""){
                $("#huesped-alert").ccsaNotificationError("Indique un periodo");
            }
            else{
                var dataSerialized = $('#txtNombreHuesped').val();
                window.location = 'Huespedes/GenerarReporteGeneral?NombreHuesped='
                    + $('#txtNombreHuesped').val()
                    +'&FechaInicio=' + $('#FechaInicioFiltro').val()
                    +'&FechaFinFiltro=' + $('#FechaFinFiltro').val()
                    +'&CodigoTipoDocumento=' + $('#cbTipoNacionalidadReporte').val()
                    +'&CodigoPais=' + $('#cbTipoDocumentoReporte').val()
                ;
            }
        });

        //$(document).on("click", "#btnExportar", null, function () {
        //    $("#prop1").empty();
        //    var searchIDs = $("#checkbox input:checkbox:checked").map(function () {
        //        var columnValue = $(this).attr('name');

        //        $("#prop1").append("<input type='hidden' name='values' value=" + columnValue + " />");
        //        return columnValue;
        //    }).get();

        //    if (searchIDs.length != 0) {
        //        console.log(searchIDs);
        //        var dataSerialized = $("#formReporteGeneral").find("select, input[name!='FechaFin'][name!='FechaInicio']").serialize();
        //        var endDate = $("input[name='FechaFin']").data("DateTimePicker").date().format("MM/DD/YYYY");
        //        var startDate = $("input[name='FechaInicio']").data("DateTimePicker").date().format("MM/DD/YYYY");
        //        dataSerialized += "&FechaInicio=" + startDate + "&FechaFin=" + endDate;

        //        window.location = "Report/GenerarReporteGeneralConFiltros?" + dataSerialized
        //    }
        //    else {
        //        var alert = GenerateAlert("danger", "Debe seleccionar al menos una columna para generar el reporte");
        //        $('#ReportAlert').empty();
        //        $('#ReportAlert').append(alert);
        //    }
        //});

        $("#btnLimpiar").click(function () {
            $("#txtNombre").val("");
        });


        $('#txtNombre').keyup(function (e) {
            if (e.keyCode == 13) {
                // $('#paginacionFoot').pagination('selectPage', 1);
                $(polizasTable).jtable('load', {
                    texto: $("#txtNombre").val()
                    
                });

            }
        });
        //Editar

        $(document).on("click", "#btnEditarFamilia", null, function () {
          
            $("#modal-fami").modal("show");
          
        });

        function formatMoney(number, places, symbol, thousand, decimal) {
            number = number || 0;
            places = !isNaN(places = Math.abs(places)) ? places : 2;
            symbol = symbol !== undefined ? symbol : "$";
            thousand = thousand || ",";
            decimal = decimal || ".";
            var negative = number < 0 ? "-" : "",
                i = parseInt(number = Math.abs(+number || 0).toFixed(places), 10) + "",
                j = (j = i.length) > 3 ? j % 3 : 0;
            return symbol + negative + (j ? i.substr(0, j) + thousand : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + thousand) + (places ? decimal + Math.abs(number - i).toFixed(places).slice(2) : "");
        }
    });
})(window.sinisterNamespace = window.sinisterNamespace || {}, jQuery);