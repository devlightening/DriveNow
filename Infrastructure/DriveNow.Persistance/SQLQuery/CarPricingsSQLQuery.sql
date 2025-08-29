-- Koleos SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '87ecdc66-5267-452f-af73-02a03359fbf5', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 25),
(NEWID(), '87ecdc66-5267-452f-af73-02a03359fbf5', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 120),
(NEWID(), '87ecdc66-5267-452f-af73-02a03359fbf5', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 750),
(NEWID(), '87ecdc66-5267-452f-af73-02a03359fbf5', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2800);

-- Focus Estate (Estate)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'c5e38cdf-aa24-42ea-99fd-0775fe33b68a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 18),
(NEWID(), 'c5e38cdf-aa24-42ea-99fd-0775fe33b68a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 90),
(NEWID(), 'c5e38cdf-aa24-42ea-99fd-0775fe33b68a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 550),
(NEWID(), 'c5e38cdf-aa24-42ea-99fd-0775fe33b68a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2000);

-- Pacifica Minivan (Minivan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '33bffacd-319c-49dd-9079-08c4bd2202c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 30),
(NEWID(), '33bffacd-319c-49dd-9079-08c4bd2202c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 150),
(NEWID(), '33bffacd-319c-49dd-9079-08c4bd2202c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 900),
(NEWID(), '33bffacd-319c-49dd-9079-08c4bd2202c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3200);

-- 5 Series Sedan (Sedan/Luxury)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '6dea1e05-cafb-44b3-bcdc-099b8ca25275', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 45),
(NEWID(), '6dea1e05-cafb-44b3-bcdc-099b8ca25275', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 220),
(NEWID(), '6dea1e05-cafb-44b3-bcdc-099b8ca25275', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1400),
(NEWID(), '6dea1e05-cafb-44b3-bcdc-099b8ca25275', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 5000);

-- Model 3 (Electric Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '866f1c58-8e7f-42e0-a698-19719459012e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 35),
(NEWID(), '866f1c58-8e7f-42e0-a698-19719459012e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 180),
(NEWID(), '866f1c58-8e7f-42e0-a698-19719459012e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1100),
(NEWID(), '866f1c58-8e7f-42e0-a698-19719459012e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 4000);

-- Pathfinder SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'd1884bdc-ddb7-4f2f-82c8-1c7b86ef8a52', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 28),
(NEWID(), 'd1884bdc-ddb7-4f2f-82c8-1c7b86ef8a52', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 140),
(NEWID(), 'd1884bdc-ddb7-4f2f-82c8-1c7b86ef8a52', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), 'd1884bdc-ddb7-4f2f-82c8-1c7b86ef8a52', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- 300 Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '68cca2de-fec4-4c34-b566-1cddbc763218', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 22),
(NEWID(), '68cca2de-fec4-4c34-b566-1cddbc763218', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 110),
(NEWID(), '68cca2de-fec4-4c34-b566-1cddbc763218', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 650),
(NEWID(), '68cca2de-fec4-4c34-b566-1cddbc763218', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2400);

-- 508 Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '385921f5-0b28-43bc-81c0-1d7ec79a2c09', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 20),
(NEWID(), '385921f5-0b28-43bc-81c0-1d7ec79a2c09', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 100),
(NEWID(), '385921f5-0b28-43bc-81c0-1d7ec79a2c09', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 600),
(NEWID(), '385921f5-0b28-43bc-81c0-1d7ec79a2c09', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2200);

-- CX-5 SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'a7e14bf0-1ff8-4705-bc0c-1fff1b53844f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 25),
(NEWID(), 'a7e14bf0-1ff8-4705-bc0c-1fff1b53844f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 125),
(NEWID(), 'a7e14bf0-1ff8-4705-bc0c-1fff1b53844f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 800),
(NEWID(), 'a7e14bf0-1ff8-4705-bc0c-1fff1b53844f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2900);

-- Qashqai SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '5394b908-edfd-4d94-b75e-21e590435456', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 24),
(NEWID(), '5394b908-edfd-4d94-b75e-21e590435456', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 120),
(NEWID(), '5394b908-edfd-4d94-b75e-21e590435456', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 750),
(NEWID(), '5394b908-edfd-4d94-b75e-21e590435456', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2800);

-- Tiguan SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'd452ddba-7258-45ba-aa2d-23990e8cdb27', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 26),
(NEWID(), 'd452ddba-7258-45ba-aa2d-23990e8cdb27', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 130),
(NEWID(), 'd452ddba-7258-45ba-aa2d-23990e8cdb27', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 820),
(NEWID(), 'd452ddba-7258-45ba-aa2d-23990e8cdb27', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3000);

-- 6 Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '66e6808b-6262-406c-a4f9-2a9bd08b39a1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 20),
(NEWID(), '66e6808b-6262-406c-a4f9-2a9bd08b39a1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 105),
(NEWID(), '66e6808b-6262-406c-a4f9-2a9bd08b39a1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 620),
(NEWID(), '66e6808b-6262-406c-a4f9-2a9bd08b39a1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2300);

-- Corolla Hatchback (Hatchback)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'df8d4b74-4706-4d81-a77e-3011834e740b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 17),
(NEWID(), 'df8d4b74-4706-4d81-a77e-3011834e740b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 85),
(NEWID(), 'df8d4b74-4706-4d81-a77e-3011834e740b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 500),
(NEWID(), 'df8d4b74-4706-4d81-a77e-3011834e740b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 1800);

-- Tahoe SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'a238ac34-43d1-4e32-b6e9-3289fccacd95', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 35),
(NEWID(), 'a238ac34-43d1-4e32-b6e9-3289fccacd95', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 175),
(NEWID(), 'a238ac34-43d1-4e32-b6e9-3289fccacd95', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1100),
(NEWID(), 'a238ac34-43d1-4e32-b6e9-3289fccacd95', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 4000);

-- Q5 SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '1e0e4095-71f5-40f1-b351-37feea774c46', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 30),
(NEWID(), '1e0e4095-71f5-40f1-b351-37feea774c46', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 160),
(NEWID(), '1e0e4095-71f5-40f1-b351-37feea774c46', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1000),
(NEWID(), '1e0e4095-71f5-40f1-b351-37feea774c46', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3800);

-- 3 Series Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '8d642c00-7b61-4c6d-95fd-3ccbedecd628', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 28),
(NEWID(), '8d642c00-7b61-4c6d-95fd-3ccbedecd628', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 140),
(NEWID(), '8d642c00-7b61-4c6d-95fd-3ccbedecd628', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), '8d642c00-7b61-4c6d-95fd-3ccbedecd628', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- Outback StationWagon (Station Wagon)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'b6ddac00-398b-40a2-9639-3d9ea6fd06f1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 25),
(NEWID(), 'b6ddac00-398b-40a2-9639-3d9ea6fd06f1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 120),
(NEWID(), 'b6ddac00-398b-40a2-9639-3d9ea6fd06f1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 750),
(NEWID(), 'b6ddac00-398b-40a2-9639-3d9ea6fd06f1', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2800);

-- Tucson SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'e075d32c-6032-4f83-bb94-400557f38522', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 23),
(NEWID(), 'e075d32c-6032-4f83-bb94-400557f38522', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 115),
(NEWID(), 'e075d32c-6032-4f83-bb94-400557f38522', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 700),
(NEWID(), 'e075d32c-6032-4f83-bb94-400557f38522', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2600);

-- Megane Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '6278bd66-dd23-48c7-a120-50ab560f7993', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 19),
(NEWID(), '6278bd66-dd23-48c7-a120-50ab560f7993', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 95),
(NEWID(), '6278bd66-dd23-48c7-a120-50ab560f7993', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 580),
(NEWID(), '6278bd66-dd23-48c7-a120-50ab560f7993', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2100);

-- Impreza Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'c0448eb8-7ad4-496c-808e-510ce528596c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 20),
(NEWID(), 'c0448eb8-7ad4-496c-808e-510ce528596c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 100),
(NEWID(), 'c0448eb8-7ad4-496c-808e-510ce528596c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 600),
(NEWID(), 'c0448eb8-7ad4-496c-808e-510ce528596c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2200);

-- 911 Carrera Coupe (Luxury/Sport)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'de15e92e-0179-4f9d-8798-5246e23f4c5b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 80),
(NEWID(), 'de15e92e-0179-4f9d-8798-5246e23f4c5b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 400),
(NEWID(), 'de15e92e-0179-4f9d-8798-5246e23f4c5b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 2500),
(NEWID(), 'de15e92e-0179-4f9d-8798-5246e23f4c5b', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 9000);

-- Camry Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'e9963407-c9f4-41df-824d-53474812bce2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 21),
(NEWID(), 'e9963407-c9f4-41df-824d-53474812bce2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 105),
(NEWID(), 'e9963407-c9f4-41df-824d-53474812bce2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 650),
(NEWID(), 'e9963407-c9f4-41df-824d-53474812bce2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2400);

-- X5 SUV (SUV/Luxury)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '1e903d9a-3ab2-41e7-8d46-5ab385554691', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 50),
(NEWID(), '1e903d9a-3ab2-41e7-8d46-5ab385554691', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 250),
(NEWID(), '1e903d9a-3ab2-41e7-8d46-5ab385554691', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1500),
(NEWID(), '1e903d9a-3ab2-41e7-8d46-5ab385554691', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 5500);

-- S60 Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '49817715-c9a7-4c94-afc6-5d7966cc6f6c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 26),
(NEWID(), '49817715-c9a7-4c94-afc6-5d7966cc6f6c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 130),
(NEWID(), '49817715-c9a7-4c94-afc6-5d7966cc6f6c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 800),
(NEWID(), '49817715-c9a7-4c94-afc6-5d7966cc6f6c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3000);

-- Civic Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'cd7b8f9d-2dcf-447a-8058-6c9d3dce84da', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 18),
(NEWID(), 'cd7b8f9d-2dcf-447a-8058-6c9d3dce84da', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 90),
(NEWID(), 'cd7b8f9d-2dcf-447a-8058-6c9d3dce84da', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 550),
(NEWID(), 'cd7b8f9d-2dcf-447a-8058-6c9d3dce84da', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2000);

-- Panamera Sedan (Luxury Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '6db097b9-6bfd-4982-b14e-74701ac431b2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 60),
(NEWID(), '6db097b9-6bfd-4982-b14e-74701ac431b2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 300),
(NEWID(), '6db097b9-6bfd-4982-b14e-74701ac431b2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1900),
(NEWID(), '6db097b9-6bfd-4982-b14e-74701ac431b2', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 7000);

-- S90 Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'b8a95a74-ce1e-4376-86db-77a980f71cc8', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 28),
(NEWID(), 'b8a95a74-ce1e-4376-86db-77a980f71cc8', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 140),
(NEWID(), 'b8a95a74-ce1e-4376-86db-77a980f71cc8', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), 'b8a95a74-ce1e-4376-86db-77a980f71cc8', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- Elantra Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '8a15ef2c-6ae5-485f-82b1-872f6a0512ef', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 17),
(NEWID(), '8a15ef2c-6ae5-485f-82b1-872f6a0512ef', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 85),
(NEWID(), '8a15ef2c-6ae5-485f-82b1-872f6a0512ef', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 500),
(NEWID(), '8a15ef2c-6ae5-485f-82b1-872f6a0512ef', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 1800);

-- Macan SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '2b6f663f-d313-4295-86f9-89c8a2ad4899', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 40),
(NEWID(), '2b6f663f-d313-4295-86f9-89c8a2ad4899', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 200),
(NEWID(), '2b6f663f-d313-4295-86f9-89c8a2ad4899', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1200),
(NEWID(), '2b6f663f-d313-4295-86f9-89c8a2ad4899', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 4500);

-- Clio Hatchback (Hatchback)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'd4703e71-9520-45e6-be6b-8e8f7f673e47', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 15),
(NEWID(), 'd4703e71-9520-45e6-be6b-8e8f7f673e47', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 75),
(NEWID(), 'd4703e71-9520-45e6-be6b-8e8f7f673e47', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 450),
(NEWID(), 'd4703e71-9520-45e6-be6b-8e8f7f673e47', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 1600);

-- Silverado Pickup (Pickup)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '249c558b-043f-4312-9412-8eb29bb75436', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 35),
(NEWID(), '249c558b-043f-4312-9412-8eb29bb75436', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 170),
(NEWID(), '249c558b-043f-4312-9412-8eb29bb75436', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1050),
(NEWID(), '249c558b-043f-4312-9412-8eb29bb75436', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3800);

-- Jetta Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '0ffe2f0a-a531-4f46-a8af-9097eae30b1d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 18),
(NEWID(), '0ffe2f0a-a531-4f46-a8af-9097eae30b1d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 90),
(NEWID(), '0ffe2f0a-a531-4f46-a8af-9097eae30b1d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 550),
(NEWID(), '0ffe2f0a-a531-4f46-a8af-9097eae30b1d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2000);

-- Z4 Roadster (Roadster/Sport)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'cb559c98-1ee9-46f0-b8c9-9098a38b9e9c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 50),
(NEWID(), 'cb559c98-1ee9-46f0-b8c9-9098a38b9e9c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 250),
(NEWID(), 'cb559c98-1ee9-46f0-b8c9-9098a38b9e9c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1500),
(NEWID(), 'cb559c98-1ee9-46f0-b8c9-9098a38b9e9c', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 5500);

-- A4 Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '828b2b4c-a1f8-461f-98c6-91ea2000152e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 27),
(NEWID(), '828b2b4c-a1f8-461f-98c6-91ea2000152e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 135),
(NEWID(), '828b2b4c-a1f8-461f-98c6-91ea2000152e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), '828b2b4c-a1f8-461f-98c6-91ea2000152e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- CR-V SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '5f8b765d-4603-43f7-87da-91f201f2c774', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 24),
(NEWID(), '5f8b765d-4603-43f7-87da-91f201f2c774', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 120),
(NEWID(), '5f8b765d-4603-43f7-87da-91f201f2c774', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 750),
(NEWID(), '5f8b765d-4603-43f7-87da-91f201f2c774', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2800);

-- Highlander SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'f8a92baa-90ed-4b9d-be62-942d99e6cb76', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 30),
(NEWID(), 'f8a92baa-90ed-4b9d-be62-942d99e6cb76', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 150),
(NEWID(), 'f8a92baa-90ed-4b9d-be62-942d99e6cb76', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 900),
(NEWID(), 'f8a92baa-90ed-4b9d-be62-942d99e6cb76', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3200);

-- Santa Fe SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '9fdbd767-9b71-4712-9c2d-9520047efd8f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 26),
(NEWID(), '9fdbd767-9b71-4712-9c2d-9520047efd8f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 130),
(NEWID(), '9fdbd767-9b71-4712-9c2d-9520047efd8f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 800),
(NEWID(), '9fdbd767-9b71-4712-9c2d-9520047efd8f', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2900);

-- Mustang Coupe (Coupe/Sport)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '41d664db-0d44-4143-8a39-986508155572', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 40),
(NEWID(), '41d664db-0d44-4143-8a39-986508155572', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 200),
(NEWID(), '41d664db-0d44-4143-8a39-986508155572', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1200),
(NEWID(), '41d664db-0d44-4143-8a39-986508155572', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 4500);

-- Explorer SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'eabe87b6-d368-401e-9bde-9b8c36581850', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 28),
(NEWID(), 'eabe87b6-d368-401e-9bde-9b8c36581850', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 140),
(NEWID(), 'eabe87b6-d368-401e-9bde-9b8c36581850', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), 'eabe87b6-d368-401e-9bde-9b8c36581850', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- F-150 Pickup (Pickup)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '74691bc3-9fdc-49f9-ab5f-9bc64176659e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 32),
(NEWID(), '74691bc3-9fdc-49f9-ab5f-9bc64176659e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 160),
(NEWID(), '74691bc3-9fdc-49f9-ab5f-9bc64176659e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 950),
(NEWID(), '74691bc3-9fdc-49f9-ab5f-9bc64176659e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3500);

-- XC90 SUV (SUV/Luxury)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '912be723-60fe-4074-81a8-9ef12a7bb63e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 38),
(NEWID(), '912be723-60fe-4074-81a8-9ef12a7bb63e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 190),
(NEWID(), '912be723-60fe-4074-81a8-9ef12a7bb63e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1150),
(NEWID(), '912be723-60fe-4074-81a8-9ef12a7bb63e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 4200);

-- Golf Hatchback (Hatchback)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'c263c5e2-1a77-46e3-b4a4-a2b8de43d5ba', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 17),
(NEWID(), 'c263c5e2-1a77-46e3-b4a4-a2b8de43d5ba', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 85),
(NEWID(), 'c263c5e2-1a77-46e3-b4a4-a2b8de43d5ba', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 500),
(NEWID(), 'c263c5e2-1a77-46e3-b4a4-a2b8de43d5ba', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 1800);

-- Kona Electric (Electric SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '33873477-0090-4bcc-8cf1-a59042a5cb36', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 28),
(NEWID(), '33873477-0090-4bcc-8cf1-a59042a5cb36', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 140),
(NEWID(), '33873477-0090-4bcc-8cf1-a59042a5cb36', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), '33873477-0090-4bcc-8cf1-a59042a5cb36', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- Octavia Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '6a34754d-429c-45ed-bead-a95cec2b4eb0', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 19),
(NEWID(), '6a34754d-429c-45ed-bead-a95cec2b4eb0', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 95),
(NEWID(), '6a34754d-429c-45ed-bead-a95cec2b4eb0', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 580),
(NEWID(), '6a34754d-429c-45ed-bead-a95cec2b4eb0', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2100);

-- Model Y SUV (Electric SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '2a1e63ef-7c92-4088-8760-adacac44d1c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 38),
(NEWID(), '2a1e63ef-7c92-4088-8760-adacac44d1c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 190),
(NEWID(), '2a1e63ef-7c92-4088-8760-adacac44d1c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1150),
(NEWID(), '2a1e63ef-7c92-4088-8760-adacac44d1c7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 4200);

-- Prius Hybrid (Hybrid)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'c7b673c5-4e03-41ed-80cc-b33626bc6f86', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 22),
(NEWID(), 'c7b673c5-4e03-41ed-80cc-b33626bc6f86', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 110),
(NEWID(), 'c7b673c5-4e03-41ed-80cc-b33626bc6f86', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 650),
(NEWID(), 'c7b673c5-4e03-41ed-80cc-b33626bc6f86', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2400);

-- 308 Hatchback (Hatchback)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '7b52a14d-d891-4ae8-a7a8-b47c7b31cc88', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 16),
(NEWID(), '7b52a14d-d891-4ae8-a7a8-b47c7b31cc88', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 80),
(NEWID(), '7b52a14d-d891-4ae8-a7a8-b47c7b31cc88', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 480),
(NEWID(), '7b52a14d-d891-4ae8-a7a8-b47c7b31cc88', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 1700);

-- Forester SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '39f33355-5c93-430c-af8c-b54a50ca8128', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 25),
(NEWID(), '39f33355-5c93-430c-af8c-b54a50ca8128', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 125),
(NEWID(), '39f33355-5c93-430c-af8c-b54a50ca8128', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 800),
(NEWID(), '39f33355-5c93-430c-af8c-b54a50ca8128', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2900);

-- i4 Coupe (Electric Coupe)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'cd9a37f1-760f-4e9e-864b-bc1a7c1f885a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 55),
(NEWID(), 'cd9a37f1-760f-4e9e-864b-bc1a7c1f885a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 275),
(NEWID(), 'cd9a37f1-760f-4e9e-864b-bc1a7c1f885a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 1700),
(NEWID(), 'cd9a37f1-760f-4e9e-864b-bc1a7c1f885a', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 6000);

-- 3 Hatchback (Hatchback)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '998d7155-e0a5-4abb-b892-c1ffd0bdfa59', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 17),
(NEWID(), '998d7155-e0a5-4abb-b892-c1ffd0bdfa59', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 85),
(NEWID(), '998d7155-e0a5-4abb-b892-c1ffd0bdfa59', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 500),
(NEWID(), '998d7155-e0a5-4abb-b892-c1ffd0bdfa59', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 1800);

-- Escape Hybrid (Hybrid SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'c0879f92-64c3-4a82-b583-d797b89a7156', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 27),
(NEWID(), 'c0879f92-64c3-4a82-b583-d797b89a7156', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 135),
(NEWID(), 'c0879f92-64c3-4a82-b583-d797b89a7156', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), 'c0879f92-64c3-4a82-b583-d797b89a7156', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- Juke Hatchback (Hatchback/Subcompact SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'f7f12802-90b9-4249-881d-d914e62e4ff7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 20),
(NEWID(), 'f7f12802-90b9-4249-881d-d914e62e4ff7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 100),
(NEWID(), 'f7f12802-90b9-4249-881d-d914e62e4ff7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 600),
(NEWID(), 'f7f12802-90b9-4249-881d-d914e62e4ff7', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2200);

-- A3 Hatchback (Hatchback/Luxury)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '17c8c4a8-4d4c-40d7-b0f4-e827d1dfa1b3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 24),
(NEWID(), '17c8c4a8-4d4c-40d7-b0f4-e827d1dfa1b3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 120),
(NEWID(), '17c8c4a8-4d4c-40d7-b0f4-e827d1dfa1b3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 750),
(NEWID(), '17c8c4a8-4d4c-40d7-b0f4-e827d1dfa1b3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2800);

-- Passat Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), 'd1bf1727-3d44-4c56-ae1a-ebce724223c3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 20),
(NEWID(), 'd1bf1727-3d44-4c56-ae1a-ebce724223c3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 100),
(NEWID(), 'd1bf1727-3d44-4c56-ae1a-ebce724223c3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 600),
(NEWID(), 'd1bf1727-3d44-4c56-ae1a-ebce724223c3', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2200);

-- Malibu Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '70f7fe33-4e06-4a5c-9a65-ecedc6a435ad', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 19),
(NEWID(), '70f7fe33-4e06-4a5c-9a65-ecedc6a435ad', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 95),
(NEWID(), '70f7fe33-4e06-4a5c-9a65-ecedc6a435ad', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 580),
(NEWID(), '70f7fe33-4e06-4a5c-9a65-ecedc6a435ad', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2100);

-- Kodiaq SUV (SUV)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '285f2a9d-46cd-4f92-8577-effa6e78687e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 28),
(NEWID(), '285f2a9d-46cd-4f92-8577-effa6e78687e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 140),
(NEWID(), '285f2a9d-46cd-4f92-8577-effa6e78687e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 850),
(NEWID(), '285f2a9d-46cd-4f92-8577-effa6e78687e', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 3100);

-- Superb Sedan (Sedan)
INSERT INTO CarPricings (CarPricingId, CarId, PricingId, Price)
VALUES
(NEWID(), '30c7d3d0-a638-4a03-843a-fcb08a79b88d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Hourly'), 22),
(NEWID(), '30c7d3d0-a638-4a03-843a-fcb08a79b88d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Daily'), 110),
(NEWID(), '30c7d3d0-a638-4a03-843a-fcb08a79b88d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Weekly'), 650),
(NEWID(), '30c7d3d0-a638-4a03-843a-fcb08a79b88d', (SELECT PricingId FROM Pricings WHERE PricingName = 'Monthly'), 2400);