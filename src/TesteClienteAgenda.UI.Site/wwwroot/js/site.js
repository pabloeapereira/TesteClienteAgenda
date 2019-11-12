// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $("#cnpj").inputmask("mask", { "mask": "99.999.999/9999-99" }, { reverse: true });
    $("#date").inputmask("mask", { "mask": "99/99/9999" });
});

function RetirarMascaraCnpj(cnpj) {
    return cnpj.value.replace(/[^\d]+/g, '');
}