const btnJogador = document.getElementById("btnJogador");
const btnDesenvolvedor = document.getElementById("btnDesenvolvedor");
const tipoConta = document.getElementById("tipoConta");

btnJogador.onclick = () => {
    btnJogador.classList.add("active");
    btnDesenvolvedor.classList.remove("active");
    tipoConta.value = "jogador";
};

btnDesenvolvedor.onclick = () => {
    btnDesenvolvedor.classList.add("active");
    btnJogador.classList.remove("active");
    tipoConta.value = "desenvolvedor";
};

btnJogador.classList.add("active");
tipoConta.value = "jogador";
