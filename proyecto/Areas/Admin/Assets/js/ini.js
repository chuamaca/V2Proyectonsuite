$(document).ready(function () {
    $("body").on('click', 'button', function () {

        // Si el boton no tiene el atributo ajax no hacemos nada
        if ($(this).data('ajax') == undefined) return;

        // El metodo .data identifica la entrada y la castea al valor más correcto
        if ($(this).data('ajax') != true) return;

        var form = $(this).closest("form");
        var buttons = $("button", form);
        var button = $(this);
        var url = form.attr('action');
        $(document).ready(function () {
            $("body").on('click', 'button', function (e) {
                e.preventDefault();

                // Si el boton no tiene el atributo ajax no hacemos nada
                if ($(this).data('ajax') == undefined) return;

                // El metodo .data identifica la entrada y la castea al valor más correcto
                if ($(this).data('ajax') != true) return;

                var form = $(this).closest("form");
                var buttons = $("button", form);
                var button = $(this);
                var url = form.attr('action');

                if (button.data('confirm') != undefined) {
                    if (button.data('confirm') == '') {
                        if (!confirm('¿Esta seguro de realizar esta acción?')) return false;
                    } else {
                        if (!confirm(button.data('confirm'))) return false;
                    }
                }

                if (button.data('delete') != undefined) {
                    if (button.data('delete') == true) {
                        url = button.data('url');
                    }
                } else {
                    if (!form.valid()) {
                        return false;
                    }
                }

                // Creamos un div que bloqueara todo el formulario
                var block = $('<div class="block-loading" />');
                form.prepend(block);

                // En caso de que haya habido un mensaje de alerta
                $(".alert", form).remove();

                // Para los formularios que tengan CKupdate
                if (form.hasClass('CKupdate')) CKupdate();

                form.ajaxSubmit({
                    dataType: 'JSON',
                    type: 'POST',
                    url: url,
                    success: function (r) {
                        block.remove();
                        if (r.response) {
                            if (!button.data('reset') != undefined) {
                                if (button.data('reset')) form.reset();
                            }
                            else {
                                form.find('input:file').val('');
                            }
                        }



                        // Mostrar mensaje
                        if (r.message != null) {
                            if (r.message.length > 0) {
                                var red = "";
                                var css = "";
                                if (r.response) css = "success";
                                else css = "warning";

                                if (r.response) msg = "Correcto";
                                else msg = "Upps";

                                if (r.href != null) {
                                    if (r.href == 'self') redi = 'window.location.reload(true)'
                                    else redi = 'window.location.href = "' + r.href + '"'
                                } else {
                                    redi = '';
                                }

                                var message = '<script>Swal.fire({'
                               + '  title: "' + msg + '",'
                               + '  text: "' + r.message + '",'
                               + '  icon: "' + css + '",'
                              // +'  showCancelButton: true,'
                               + '  confirmButtonColor: "bg-success",'
                           //    +'  cancelButtonColor: "#d33",'
                               + '  confirmButtonText: "OK"'
                            + ' }).then((result) => {'
                            + '     if (result.value) {'
                              + redi
                               + '  }'
                          + '   })</script>';
                                //        var message = '<div class="alert ' + css + ' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + r.message + '</div>';
                                form.prepend(message);
                            }
                        }

                        // Ejecutar funciones
                        if (r.function != null) {
                            setTimeout(r.function, 0);
                        }
                        // Redireccionar
                        //-- if (r.href != null) {
                        //--     if (r.href == 'self') window.location.reload(true);
                        //--     else window.location.href = r.href;
                        //-- }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        block.remove();
                        form.prepend('<div class="alert alert-warning alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + errorThrown + ' | <b>' + textStatus + '</b></div>');
                    }
                });

                return false;
            })
        })

        jQuery.fn.reset = function () {
            $("input:password,input:file,input:text,textarea", $(this)).val('');
            $("input:checkbox:checked", $(this)).click();
            $("select").each(function () {
                $(this).val($("option:first", $(this)).val());
            })
        };
        if (button.data('confirm') != undefined) {
            if (button.data('confirm') == '') {
                if (!confirm('¿Esta seguro de realizar esta acción?')) return false;
            } else {
                if (!confirm(button.data('confirm'))) return false;
            }
        }

        if (button.data('delete') != undefined) {
            if (button.data('delete') == true) {
                url = button.data('url');
            }
        } else {
            if (!form.valid()) {
                return false;
            }
        }

        // Creamos un div que bloqueara todo el formulario
        var block = $('<div class="block-loading" />');
        form.prepend(block);

        // En caso de que haya habido un mensaje de alerta
        $(".alert", form).remove();

        // Para los formularios que tengan CKupdate
        if (form.hasClass('CKupdate')) CKupdate();

        form.ajaxSubmit({
            dataType: 'JSON',
            type: 'POST',
            url: url,
            beforeSend: function () {
                // setting a timeout
                console.log('cargando')
                $("#cargando").modal();
            },
            success: function (r) {
                console.log(r)
                console.log('aya ' + r.message)


                //   block.remove();
                if (r.response) {
                    if (!button.data('reset') != undefined) {
                        if (button.data('reset')) form.reset();
                    }
                    else {
                        form.find('input:file').val('');
                    }
                }



                // Mostrar mensaje
                if (r.message != null) {
                    if (r.message.length > 0) {
                        var red = "";
                        var css = "";
                        if (r.response) css = "success";
                        else css = "warning";

                        if (r.response) msg = "Correcto";
                        else msg = "Upps";

                        if (r.href != null) {
                            if (r.href == 'self') redi = 'window.location.reload(true)'
                            else redi = 'window.location.href = "' + r.href + '"'
                        } else {
                            redi = '';
                        }

                        var message = '<script>Swal.fire({'
                       + '  title: "' + msg + '",'
                       + '  text: "' + r.message + '",'
                       + '  icon: "' + css + '",'
                      // +'  showCancelButton: true,'
                       + '  confirmButtonColor: "bg-success",'
                   //    +'  cancelButtonColor: "#d33",'
                       + '  confirmButtonText: "OK"'
                    + ' }).then((result) => {'
                    + '     if (result.value) {'
                      + redi
                       + '  }'
                  + '   })</script>';
                        //        var message = '<div class="alert ' + css + ' alert-dismissable"><button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + r.message + '</div>';
                        form.prepend(message);
                    }
                }

                // Ejecutar funciones
                if (r.function != null) {
                    setTimeout(r.function, 0);
                }
                // Redireccionar
                //-- if (r.href != null) {
                //--     if (r.href == 'self') window.location.reload(true);
                //--     else window.location.href = r.href;
                //-- }

            },
            error: function (xhr) { // if error occured
                console.log(xhr)
                alert("ERROR " + xhr.status + ' ' + xhr.statusText);

            },
            complete: function (msgre) {
                console.log('se completo')
                $('#cargando').modal('hide')
            }
        });

        return false;
    })
})

jQuery.fn.reset = function () {
    $("input:password,input:file,input:text,textarea", $(this)).val('');
    $("input:checkbox:checked", $(this)).click();
    $("select").each(function () {
        $(this).val($("option:first", $(this)).val());
    })
};