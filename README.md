# Estagiado
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/coivan/Estagiado/blob/main/LICENSE) 

# Sobre o projeto

Estagiado é uma aplicação desktop escrita em C# para a disciplina de Linguagem de Programação II do IFSP de Campinas. 

A proposta da aplicação é conectar empresas e estudantes em busca de estágio. 

Ela é estruturada no padrão MVC e se conecta a um banco de dados relacional MySQL. Nela há áreas distitas para empresas e estudantes. Às empresas são permidos os processos de registro no sistema, cadastro de vagas, acompanhamento de processos de seleção, e gestão de suas informações. Aos estudantes são permidos os processos de registro no sistema, cadastro de currículo, inscrição nas vagas disponíveis, e gestão de suas informações pessoais. O sistema busca manter a consistência de todas essas operações. O Estagiado também realiza automaticamente a indicação dos candidatos mais bem cotados para determinada vaga. 

## Layout desktop
![Desktop 1](https://github.com/coivan/assets/blob/main/estagiado/tela_principal.png) 
![Desktop 2](https://github.com/coivan/assets/blob/main/estagiado/area_empresa.png)
![Desktop 3](https://github.com/coivan/assets/blob/main/estagiado/cadastro_empresa.png)
![Desktop 4](https://github.com/coivan/assets/blob/main/estagiado/area_restrita_empresa.png)
![Desktop 5](https://github.com/coivan/assets/blob/main/estagiado/area_estudante.png)
![Desktop 6](https://github.com/coivan/assets/blob/main/estagiado/cadastro_estudante.png)
![Desktop 7](https://github.com/coivan/assets/blob/main/estagiado/area_restrita_estudante.png)

## Modelo relacional do banco de dados
![Modelo Conceitual](https://github.com/coivan/assets/blob/main/estagiado/MRel_ProjetoInterdisciplinar.jpeg)

# Tecnologias utilizadas
## Back end 
- C#
- MySQL
## Front end
- Windows Forms

## Implantação em produção
- Não enviado para produção

# Como executar o projeto localmente

## Back end
Pré-requisitos: Visual Studio 2019 com .NETFramework v4.0 ou superior, banco de dados MySQL estagiado_db criado e rodando em localhost (você pode mudar as configurações de conexão no arquivo App.config) 

```bash
# 1 - clone o repositório do projeto
git clone https://github.com/coivan/Estagiado.git

# 2 - crie o banco de dados
Para criar o novo banco entre no Workbench (ou phpMyAdmin se estiver no XAMP), abra um editor de SQL e cole os comandos:

CREATE DATABASE IF NOT EXISTS estagiado_db
    CHARACTER SET utf8
    COLLATE utf8_general_ci;

USE estagiado_db;

CREATE TABLE universidade(
    id_universidade INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(150),	
    curso VARCHAR(150),
    avaliacao_mec INT,
    endereco VARCHAR(150),
    cidade VARCHAR(100),
    estado VARCHAR(5)
);

CREATE TABLE estudante(
    id_estudante INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(150),
    cpf VARCHAR(20), 
    sexo CHAR(1),
    email VARCHAR(100),
    fone VARCHAR(30),
    whatsapp VARCHAR(40),
    senha VARCHAR(100),
    endereco VARCHAR(150),
    cidade VARCHAR(100),
    estado VARCHAR(5),
    cod_universidade INT,
    nivel_acesso VARCHAR(50)
);

CREATE TABLE curriculo(
    id_curriculo INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    formacao_finlzd VARCHAR(150),
    curso_atual VARCHAR(150),
    ano_inicio INT,
    semestre_inicio VARCHAR(30),
    ano_termino INT,
    semestre_termino VARCHAR(30),
    turno_curso VARCHAR(30),
    habilidds_praticas VARCHAR(500),
    conhecmto_teorico VARCHAR(500),
    horas_diarias_disp VARCHAR(10),
    cod_estudante INT
);

CREATE TABLE candidata_se(
    cod_candidato INT,
    cod_vagaestagio INT,
    ipr_candidato DOUBLE,
    distancia_ipr_vaga DOUBLE
);

CREATE TABLE vaga_estagio(
    id_vaga INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(150),
    requisito1 VARCHAR(150),
    requisito2 VARCHAR(150),
    requisito3 VARCHAR(150),
    val_requisito1 DOUBLE,
    val_requisito2 DOUBLE,
    val_requisito3 DOUBLE,
    ipr_vaga DOUBLE,
    cod_empresa INT
);

CREATE TABLE empresa(
    id_unidd_empresa INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(150),
    cnpj VARCHAR(25),
    email_recrut VARCHAR(100),
    whatsapp VARCHAR(40),
    link_recrut VARCHAR(500),
    senha VARCHAR(100),
    endereco VARCHAR(150),
    cidade VARCHAR(100),
    estado VARCHAR(5),
    nivel_acesso VARCHAR(50)
);

ALTER TABLE `estudante` ADD CONSTRAINT `fk_estudante_universidade` FOREIGN KEY (`cod_universidade`) REFERENCES `universidade` (`id_universidade`);

ALTER TABLE `curriculo` ADD CONSTRAINT `fk_curriculo_estudante` FOREIGN KEY (`cod_estudante`) REFERENCES `estudante` (`id_estudante`);

ALTER TABLE `candidata_se` ADD CONSTRAINT `fk_estudante_vaga` FOREIGN KEY (`cod_candidato`) REFERENCES `estudante` (`id_estudante`);

ALTER TABLE `candidata_se` ADD CONSTRAINT `fk_vaga_estudante` FOREIGN KEY (`cod_vagaestagio`) REFERENCES `vaga_estagio` (`id_vaga`);

ALTER TABLE `vaga_estagio` ADD CONSTRAINT `fk_vagaestagio_empresa` FOREIGN KEY (`cod_empresa`) REFERENCES `empresa` (`id_unidd_empresa`);

# 3 - rode o projeto
Com o Visual Studio instalado e o banco de dados criado e rodando, vá na pasta do projeto e clique no arquivo Estagiado.sln
Clique no botão Start do Visual Studio ou aperte CTRL+5 para rodar a aplicação. 
Caso haja algum problema cheque a conexão com o banco de dados no arquivo App.config. 
Verifique se o seu usuário e senha correspodem ao usuario e senha do seu banco de dados recem criado.


```

## Front end 
Não requerido

## 👨🏽‍🎓 Autores
<table>
<tr>
    <td>  
        Ronald Almeida
        <br/>
        <img src="https://avatars.githubusercontent.com/u/65602274?v=4" width="100px;" alt="" style="border-radius:50%"/>
        <br/>
        Contate-me
        <p align="left">
            <a href="https://www.linkedin.com/in/ronald785/" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/linkedin/linkedin-original.svg" alt="Linkedin-icon" width="30" height="30"/>
            </a>
              &nbsp;
            <a href="https://github.com/Ronald785" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/github/github-original.svg" alt="GitHub-icon" width="30" height="30"/>
            </a>
              &nbsp;
            <a href="https://www.instagram.com/rndmateus/" target="_blank">
              <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Instagram_logo_2016.svg/2048px-Instagram_logo_2016.svg.png" alt="Instagram-icon" width="30" height="30"/>   
            </a>
              &nbsp;
            <a href="mailto:ronaldmateus785@gmail.com" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/gmail/gmail-original.svg" alt="Gmail-icon" width="30" height="30"/>
            </a>
         </p>
    </td>
    <td>
        Lucas Santos Souza
        <br/>
        <img src="https://avatars.githubusercontent.com/u/62265013?v=4" width="100px;" alt="" style="border-radius:50%"/> 
        <br/>
        Contate-me
        <p align="left">
            <a href="https://www.linkedin.com/in/lucas-souza19/" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/linkedin/linkedin-original.svg" alt="Linkedin-icon" width="30" height="30"/>
            </a>
              &nbsp;
            <a href="https://github.com/lucas-souza19" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/github/github-original.svg" width="30" height="30"/>
            </a>
            </a>
              &nbsp;
            <a href="mailto:lucassouzacps19@gmail.comm" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/gmail/gmail-original.svg" alt="Gmail-icon" width="30" height="30"/>
            </a>
         </p>
    </td>
    <td>    
        Ivan Cardoso
        <br/>
        <img src="https://avatars.githubusercontent.com/u/62209831?v=4" width="100px;" alt="" style="border-radius:50%"/> 
        <br/>
        Contate-me
        <p align="left">
            <a href="https://www.linkedin.com/in/ivan-cardoso-442691191/" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/linkedin/linkedin-original.svg" width="30" height="30"/>
            </a>
              &nbsp;
            <a href="https://github.com/coivan" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/github/github-original.svg" alt="GitHub-icon" width="30" height="30"/>
            </a>
              &nbsp;
            <a href="mailto:cardoso.ivan2012@gmail.com" target="_blank">
              <img src="https://github.com/coivan/devicon/blob/master/icons/gmail/gmail-original.svg" alt="Gmail-icon" width="30" height="30"/>
            </a>
         </p>
    </td>
</tr>
</table>


Faculdade - [Instituto Federal de Educação, Ciência e Tecnologia de São Paulo - IFSP Câmpus Campinas](https://portal.cmp.ifsp.edu.br/)
