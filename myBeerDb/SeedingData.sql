INSERT INTO myBeerDb.dbo.Brands(BrandName, Nationality)
values
('Heineken', 'Netherlands'),
('Skoll', 'Brazil'),
('Quilmes', 'Argentina'),
('Corona', 'Mexico'),
('Asahi', 'Japan'),
('Budweiser', 'The USA')

INSERT INTO myBeerDb.dbo.Containers
(CapacityInOZ, ContainerType, ContainerName)
VALUES
(11,'Bottle', 'Stubby'),
(12,'Bottle', 'Heritage'),
(12,'Bottle', 'Long Neck'),
(22,'Bottle', 'Bomber'),
(32,'Bottle', 'Mini-Growler'),
(64,'Bottle', 'Growler')

INSERT INTO myBeerDb.dbo.BeerProducts
(BrandId, ContainerId, Price)
VALUES
(1,	3,	2),
(3,	3,	2),
(1,	2,	1)