# References
Added Application.Infrastructure and Domain.Services.Data as References to WebServices in order to get the Assemblies into the output.

# Domain
## Private Settes
Private Setters are needed in order for MongoDB to write back the Data.
I think we're fine with this, since it still assures no outside logic can write the domain objects.