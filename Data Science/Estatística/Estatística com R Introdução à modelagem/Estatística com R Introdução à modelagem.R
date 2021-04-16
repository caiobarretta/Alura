# Definindo o projeto de curso
# Pergunta: O que afeta a qualidade do ar? Como?

# Carregamento da Ecdat
#Rodar Terminal: sudo apt-get install libcurl4-openssl-dev
install.packages ("RCurl")
library(RCurl)
install.packages ("bitops")
library(bitops)
install.packages("vctrs") # OK
library(vctrs)
#install.packages("MASS") install.packages("pcaPP") install.packages("rainbow")

install.packages("fds")
library(fds)
install.packages("fda")
install.packages("libxml-2.0")
install.packages("xml2")
install.packages("XML")

install.packages("Ecdat") # Se necessário

library(Ecdat) # Carregando Ecdat
#data(Airq)

#‘XML’, ‘xml2’, ‘Ecfun’