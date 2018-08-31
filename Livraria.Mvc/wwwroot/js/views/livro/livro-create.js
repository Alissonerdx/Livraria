"use strict"

$(document).ready(function () {
    Selects();
    TextArea();
    Create();
    Masks();

    function Masks() {
        $('#Ano').inputmask({ mask: "9999" });
        $('#ISBN').inputmask({ mask: "999-99-999-9999-9" });
        $('#NumeroDePaginas').inputmask({ alias: "integer", mask: "99999" });
        $('#QuantidadeEmEstoque').inputmask({ alias: "integer", mask: "99999999" });
        $('#Peso').inputmask({ alias: "numeric" });
    }

    function Create() {


        $("#livroForm").validate({
            //rules: {
            //    "Titulo": { required: true },
            //    "AutorId": { required: true },
            //    "EditoraId": { required: true }
            //},
            messages: {
                "Titulo": "Campo Titulo é obrigatório",
                "AutorId": "Ao menos um Autor deve ser selecionado",
                "EditoraId": "Ao menos uma Editora deve ser selecionada"
            }

        });

        //let form = $("#livroForm")[0];
        //let data = new FormData(form);

        //$.post("/Livro/Create", data, function (response) {

        //});
    }

    function TextArea() {
        ClassicEditor
            .create(document.querySelector('#Assunto'))
            .catch(error => {
                console.error(error);
            });
    }

    function Selects() {
        $("#AutorId").select2({
            language: "pt-BR",
            placeholder: "Selecione o Autor",
        });

        $("#EditoraId").select2({
            language: "pt-BR",
            placeholder: "Selecione a Editora",
        })
    }
});