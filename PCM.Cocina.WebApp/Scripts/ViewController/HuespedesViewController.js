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
        $('#myModalLabel').text("REGISTRAR UN HUÉSPED");
        $.ajax({ url: "Huespedes/RegistrarHuesped", type: 'get' }).done(function (data) {
            $("#modal-huesped-body").html("");

            $("#modal-huesped-body").html(data);
            $("#modal-huesped").modal('toggle');
            $("#FechaIngreso").datetimepicker({ format: "DD/MM/YYYY" });
            $("#FechaSalida").datetimepicker({ format: "DD/MM/YYYY" });
            $('#ImporteHabitacion').autoNumeric('').addClass("text-right").trigger('focusout');
            $("#modal-huesped input").first().focus();
            $("#sel-docu").filter('[autofocus]').trigger('chosen:activate');
            $(".chosen-container").first().find('input').val("");

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
        $.post('Huespedes/AgregarHuesped', {
            NombreDeHuesped: $('#txtNombreDeHuesped').val(),
            codigoGenero: $('#cbTipoGenero').val(),
            codigoPais: $('#cbNacionalidad').val(),
            codigoTipoDocumento: $('#cbCodigoDocumento').val(),
            numeroDocumento: $('#txtNumeroDocumento').val(),
            fechaIngreso: $('#FechaIngreso').val(),
            fechaSalida: $('#FechaSalida').val(),
            NumeroDeHabitacion: $('#NumeroHabitacion').val(),
            Tarifa: $('#ImporteHabitacion').val(),
            CodigoMoneda: $('#cbTipoMoneda').val()
        }, function (data) {
            if (data.Result == "OK") {

                $('#modal-huesped').modal('hide');
                $("#huesped-alert").ccsaNotificacionSuccess("Se agrego un huésped");
                sinisterNamespace.CargarTablaPolizas($("#txtNombreHuesped").val());
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
            title: 'Listado de Huéspedes',
            paging: true,
            pageSize: 10,
            actions: {
                listAction: 'Huespedes/ListarHuespedes'
            },
            fields: {
                ROW: { title: 'N°', width: '3%', edit: false, },
                CodigoRegistroHuespedes: { title: 'Codigo', width: '1%', list: false, edit: false},
                NombreHuesped: { title: 'Nombre', width: '32%' },
                DescriGenero: { title: 'Sexo', width: '5%' },
                DescriNacionalidad: { title: 'Nacionalidad', width: '7%' },
                DescriTipoDocumento: { title: 'Tipo Documento', width: '14%' },
                NumeroDocumento: { title: 'Número Documento', width: '7%' },
                FechaIngreso: { title: 'Fecha Ingreso', type: 'date', displayFormat: 'dd-mm-yy', width: '14%' },
                FechaSalida: { title: 'Fecha Salida', type: 'date', displayFormat: 'dd-mm-yy', width: '14%' },
                NumeroHabitacion: {title: 'Habitación', width: '7%', texto: 'Habitación'},
                ImporteHabitacion:
                    {
                        title: 'Tarifa',
                        width: '5%',
                        texto: 'Tarifa',
                        display: function (batch) {
                            return ((formatMoney(batch.record.ImporteHabitacion, 2,"")));
                        },
                        footer: function (data) {
                            var total = 0;
                            $.each(data.Records, function (index, record) {
                                total += Number(record.ImporteHabitacion);
                            });
                          
                            return ((total * 100).toFixed(2) + "%");
                        }
                      

                },
                SimboloMoneda: { title: 'Moneda', width: '2%', texto: 'Moneda' },
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
                 
            }
        });

  

        sinisterNamespace.CargarTablaPolizas($("#txtNombreHuesped").val());
        $(polizasTable + " table thead tr").css("background-color", "#454545").css("color", "white").css("font-weight", 300);
        //$(siniestrosTable + " table thead tr").css("background-color", "#454545").css("color", "white").css("font-weight", 300);

        $("#btnLimpiar").click(function () {
            //$("#ClientChkId").prop('checked', true);
            $("#txtNombreHuesped").val("");
            $("#FechaInicioFiltro").val("");
            $("#FechaFinFiltro").val("");
        });

        $("#btnBuscarHuespedes").click(function () {
            
            $(polizasTable).jtable('load', { texto: $("#txtNombreHuesped").val(),
                fechaInicio: $("#FechaInicioFiltro").val(),
                fechaFinal: $("#FechaFinFiltro").val(),
                CodigoTipoDocumento: $('#cbTipoDocumentoReporte').val(),
                CodigoPais: $('#cbTipoNacionalidadReporte').val()
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
            $("#txtNombreHuesped").val("");
        });


        $('#txtNombreHuesped').keyup(function (e) {
            if (e.keyCode == 13) {
                // $('#paginacionFoot').pagination('selectPage', 1);
                $(polizasTable).jtable('load', {
                    texto: $("#txtNombreHuesped").val(),
                    fechaInicio: $("#FechaInicioFiltro").val(),
                    fechaFinal: $("#FechaFinFiltro").val(),
                    CodigoTipoDocumento: $('#cbTipoNacionalidadReporte').val(),
                    CodigoPais: $('#cbTipoDocumentoReporte').val(),
                    CodigoTipoDocumento: $('#cbTipoDocumentoReporte').val(),
                    CodigoPais: $('#cbTipoNacionalidadReporte').val()
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