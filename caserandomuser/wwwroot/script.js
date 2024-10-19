// Função para carregar a lista de endereços ao iniciar a página
async function carregarEnderecos() {
    const response = await fetch("http://localhost:5175/api/enderecos/listarenderecos");
    const enderecos = await response.json();
    const enderecosBody = document.getElementById("enderecosBody");

    enderecos.forEach(endereco => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${endereco.id}</td>
            <td>${endereco.cep}</td>
            <td>${endereco.logradouro}</td>
            <td>${endereco.complemento || ''}</td>
            <td>${endereco.unidade || ''}</td>
            <td>${endereco.bairro}</td>
            <td>${endereco.localidade}</td>
            <td>${endereco.uf}</td>
            <td>${endereco.estado}</td>
            <td>${endereco.regiao}</td>
            <td>${endereco.ibge}</td>
            <td>${endereco.gia}</td>
            <td>${endereco.ddd}</td>
            <td>${endereco.siafi}</td>
        `;
        enderecosBody.appendChild(row);
    });
}

// Chamada da função para carregar os endereços ao iniciar a página
carregarEnderecos();

document.getElementById("pesquisarButton").addEventListener("click", async function() {
    const cepInput = document.getElementById("cepInput").value;
    const resultadoDiv = document.getElementById("resultadoPesquisa");
    const cadastrarButton = document.getElementById("cadastrarEnderecoButton");

    try {
        const response = await fetch(`http://localhost:5175/api/enderecos/pesquisarcep/${cepInput}`);

        if (!response.ok) {
            throw new Error("CEP não encontrado.");
        }

        const data = await response.json();

        // Limpar resultados anteriores
        resultadoDiv.innerHTML = '';

        // Preencher resultados
        resultadoDiv.innerHTML += `<p><span>CEP:</span> ${data.cep}</p>`;
        resultadoDiv.innerHTML += `<p><span>Logradouro:</span> ${data.logradouro}</p>`;
        resultadoDiv.innerHTML += `<p><span>Complemento:</span> ${data.complemento || ''}</p>`;
        resultadoDiv.innerHTML += `<p><span>Unidade:</span> ${data.unidade || ''}</p>`;
        resultadoDiv.innerHTML += `<p><span>Bairro:</span> ${data.bairro}</p>`;
        resultadoDiv.innerHTML += `<p><span>Localidade:</span> ${data.localidade}</p>`;
        resultadoDiv.innerHTML += `<p><span>UF:</span> ${data.uf}</p>`;
        resultadoDiv.innerHTML += `<p><span>Estado:</span> ${data.estado}</p>`;
        resultadoDiv.innerHTML += `<p><span>Região:</span> ${data.regiao}</p>`;
        resultadoDiv.innerHTML += `<p><span>IBGE:</span> ${data.ibge}</p>`;
        resultadoDiv.innerHTML += `<p><span>GIA:</span> ${data.gia}</p>`;
        resultadoDiv.innerHTML += `<p><span>DDD:</span> ${data.ddd}</p>`;
        resultadoDiv.innerHTML += `<p><span>SIAFI:</span> ${data.siafi}</p>`;

        // Exibir a div de resultados e o botão de cadastrar
        resultadoDiv.style.display = 'block';
        cadastrarButton.style.display = 'block';
    } catch (error) {
        alert(error.message);
        resultadoDiv.style.display = 'none';
        cadastrarButton.style.display = 'none';
    }
});
