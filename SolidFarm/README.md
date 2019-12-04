![https://github.com/jacobduijzer/Spielerei/actions?query=workflow%3ASolidFarm](https://github.com/jacobduijzer/Spielerei/workflows/SolidFarm/badge.svg) 

# Introduction

While working at a large project with some complex flows I thought of ways to implement a more S.O.L.I.D. service to filter items and create new objects with the selected items.

Imagine you have a list with actions:

- chicken 1, female, born 1-1-2019, sold 1-3-2019
- chicken 2, female, born 1-1-2019, sold 1-3-2019
- chicken 3, male, born 2-1-2019, slaughtered 31-4-2019

I want to select all sold females between 1-1-2019 and 31-1-2019 to create invoices.

While there might be many ways to Rome I want to emphasize that:

- selections might change
- new selections might be added
- creation of the invoice might be different based on selected animals

I created the following interface:

'''csharp
'''
