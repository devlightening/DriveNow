UPDATE Features
SET IconUrl = CASE FeatureName
    WHEN 'Parking Assist' THEN 'fas fa-parking'
    WHEN 'Apple CarPlay / Android Auto' THEN 'fab fa-apple'
    WHEN 'Leather Seats' THEN 'fas fa-chair'
    WHEN 'Multi-Function Steering Wheel' THEN 'fas fa-circle-notch'
    WHEN 'Continuously Variable Transmission (CVT)' THEN 'fas fa-cogs'
    WHEN 'Rear-Wheel Drive (RWD)' THEN 'fas fa-car'
    WHEN 'LED Headlights' THEN 'fas fa-lightbulb'
    WHEN 'Blind Spot Monitoring' THEN 'fas fa-eye'
    WHEN 'Automatic Headlights' THEN 'fas fa-sun'
    WHEN 'Heads-Up Display (HUD)' THEN 'fas fa-tachometer-alt'
    WHEN 'ABS (Anti-lock Braking System)' THEN 'fas fa-car-crash'
    WHEN 'Hill-Start Assist' THEN 'fas fa-mountain'
    WHEN 'Power Windows' THEN 'fas fa-window-maximize'
    WHEN 'Lane Departure Warning' THEN 'fas fa-road'
    WHEN 'Ventilated Seats' THEN 'fas fa-fan'
    WHEN 'Wireless Phone Charger' THEN 'fas fa-charging-station'
    WHEN 'Traction Control' THEN 'fas fa-snowflake'
    WHEN 'Automatic Emergency Braking' THEN 'fas fa-exclamation-triangle'
    WHEN 'Active Aerodynamics' THEN 'fas fa-wind'
    WHEN 'USB Port' THEN 'fas fa-usb'
    WHEN 'Heated Seats' THEN 'fas fa-thermometer-half'
    WHEN 'Electric Power Steering' THEN 'fas fa-car-battery'
    WHEN 'Rain-Sensing Wipers' THEN 'fas fa-cloud-showers-heavy'
    WHEN 'Voice Command System' THEN 'fas fa-microphone'
    WHEN 'Adaptive Cruise Control' THEN 'fas fa-cruise-control'
    WHEN 'Rear-View Camera' THEN 'fas fa-video'
    WHEN 'Navigation System' THEN 'fas fa-map-marked-alt'
    WHEN 'Push-Button Start' THEN 'fas fa-key'
    ELSE 'fas fa-star' -- Eþleþmeyenler için varsayýlan ikon
END
WHERE FeatureName IN (
    'Parking Assist',
    'Apple CarPlay / Android Auto',
    'Leather Seats',
    'Multi-Function Steering Wheel',
    'Continuously Variable Transmission (CVT)',
    'Rear-Wheel Drive (RWD)',
    'LED Headlights',
    'Blind Spot Monitoring',
    'Automatic Headlights',
    'Heads-Up Display (HUD)',
    'ABS (Anti-lock Braking System)',
    'Hill-Start Assist',
    'Power Windows',
    'Lane Departure Warning',
    'Ventilated Seats',
    'Wireless Phone Charger',
    'Traction Control',
    'Automatic Emergency Braking',
    'Active Aerodynamics',
    'USB Port',
    'Heated Seats',
    'Electric Power Steering',
    'Rain-Sensing Wipers',
    'Voice Command System',
    'Adaptive Cruise Control',
    'Rear-View Camera',
    'Navigation System',
    'Push-Button Start'
);