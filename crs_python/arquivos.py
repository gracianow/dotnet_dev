arquivo = open("arquivo.txt")
arquivo2 = open("archivo.txt")

#print(arquivo)
"""
linhas = arquivo.read()

linhas = arquivo.readlines()

print(linhas)

for linha in linhas :
    print(linha)
"""
w = open("archivo.txt", "w")    

w.write("Escribiendo en el archivo bajo python")

w = open("archivo.txt")
lendo = arquivo2.read()

print(lendo)

w.close()