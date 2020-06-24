/*
 
 
                                        @*<div class="form-group">
                <div class="col-md-3">
                    <select class="input-12" name="empresaorden">
                        @foreach (var c in empresas)
                        {
                            <option @(Model.empresaorden == (c.nmempresa) ? "selected" : "") value="@c.idempresa">@c.nmempresa</option>
                        }
                    </select>
                </div>
            </div>




            <div class="form-group">
                <div class="col-md-3">
                    <select class="input-12" name="sucursalorden">
                        @foreach (var c in sucursales)
                        {
                            <option @(Model.sucursalorden == (c.nmsucursal) ? "selected" : "") value="@c.idsucursal">@c.nmsucursal</option>
                        }
                    </select>
                </div>
            </div>*@




 
 
 
 
enable-migrations
add-migration InitialCreate
 
 
 
 
 
 
 
 
 
 



@*<script>


    $(document).ready(function () {

        $("#empresaorden").change(function () {

            $("#sucursalorden").empty();

            $.getJSON('/orden/GetSucursal', { idempresa: $('#empresaorden').val() }, function (data) {
                $.each(data, function () {
                    $('#sucursalorden').append('<option value=' +
                        this.Value + '>' + this.Text + '</option>');
                });
            });
        });
    });

</script>*@

@*<script>
    $(document).ready(function () {

        $("#empresaorden").change(function () {

            $("#clienteorden").empty();

            $.getJSON('/orden/GetCliente', { idempresa: $('#empresaorden').val() }, function (data) {
                $.each(data, function () {
                    $('#clienteorden').append('<option value=' +
                        this.Value + '>' + this.Text + '</option>');
                });
            });
        });
    });

</script>*@


@*<script>
    $(document).ready(function () {

        $("#empresaorden").change(function () {

            $("#clienteorden").empty();

            $.getJSON('/orden/GetCliente', { idempresa: $('#empresaorden').val() }, function (data) {
                $.each(data, function () {
                    $('#clienteorden').append('<option value=' +
                        this.Value + '>' + this.Text + '</option>');
                });
            });
        });
    });

</script>*@


@*<script>

    $(function () {

        $("#clienteorden").Autocomplete({
            Source : "/orden/GetCliente"
        });
     });



 
</script>*@





@*
    <script>
    $(document).ready(function () {

        $("#empresaorden").change(function () {

            $("#sucursalorden").empty();

            $.getJSON('/orden/GetSucursal', { idempresa: $('#empresaorden').val() }, function (data) {
                $.each(data, function () {
                    $('#sucursalorden').append('<option value=' +
                        this.Value + '>' + this.Text + '</option>');
                });
            });
        });
    });

</script>

<script>
    $(document).ready(function () {

        $("#empresaorden").change(function () {

            $("#clienteorden").empty();

            $.getJSON('/orden/GetCliente', { idempresa: $('#empresaorden').val() }, function (data) {
                $.each(data, function () {
                    $('#clienteorden').append('<option value=' +
                        this.Value + '>' + this.Text + '</option>');
                });
            });
        });
    });

</script>
    
    *@



@*@Html.LabelFor(x => x.empresaorden, new { @class = "col-sm-2 control-label pull-left" })
    <div class="col-md-3">
        @Html.DropDownList("empresaorden",  ViewBag.miempresa as List<SelectListItem>, "-- Seleccionar Empresa --", new { @class = "input-12" })
        @Html.ValidationMessageFor(x => x.empresaorden, null, new { @class = "label label-danger" })
    </div>*@



@*<div class="col-md-3">
        @Html.DropDownList("sucursalorden", new SelectList(string.Empty, "Value", "Text"), new { @class = "input-12" })
        @Html.ValidationMessageFor(x => x.sucursalorden, null, new { @class = "label label-danger" })
    </div>

    <div class="col-md-3">
        @Html.DropDownList("clienteorden", new SelectList(string.Empty, "Value", "Text"), new { @class = "input-12" })
        @Html.ValidationMessageFor(x => x.clienteorden, null, new { @class = "label label-danger" })
    </div>*@
 
 
 
 
 
 
 
 
 
 
 
 */