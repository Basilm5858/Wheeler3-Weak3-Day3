CREATE DATABASE Expense;
GO

USE Expense;
GO

CREATE TABLE expense_report
(
    Id INT IDENTITY(1,1) PRIMARY KEY,

    Name NVARCHAR(100) NOT NULL,
    Department NVARCHAR(100) NOT NULL,

    ExpenseTitle NVARCHAR(200) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL CHECK (Amount > 0),

    ExpenseDate DATE NOT NULL,

    Notes NVARCHAR(500) NULL,

    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),

    IsActive BIT NOT NULL DEFAULT 1
);

CREATE INDEX IX_expense_report_Name
ON expense_report(Name);


INSERT INTO expense_report
(Name, Department, ExpenseTitle, Amount, ExpenseDate, Notes)
VALUES
-- IT Department
('Mai', 'IT', 'Cloud Subscription', 2200.00, '2026-01-15', 'Azure Monthly Plan'),
('Mai', 'IT', 'Mouse & Keyboard', 450.00, '2026-01-18', 'Hardware replacement'),
('Omar', 'IT', 'Server Maintenance', 5000.00, '2026-02-05', 'Quarterly check'),

-- HR Department
('Ahmed', 'HR', 'Training Session', 1800.00, '2026-01-22', 'Soft skills workshop'),
('Ahmed', 'HR', 'Recruitment Ads', 950.00, '2026-02-02', 'LinkedIn Ads'),
('Salma', 'HR', 'Employee Event', 3000.00, '2026-02-10', 'Team building activity'),

-- Finance Department
('Youssef', 'Finance', 'Accounting Software', 4000.00, '2026-01-12', 'Annual license'),
('Youssef', 'Finance', 'Tax Consultation', 2500.00, '2026-02-08', 'External auditor'),
('Nour', 'Finance', 'Office Printer Ink', 600.00, '2026-02-14', 'HP Ink cartridges'),

-- Marketing Department
('Hana', 'Marketing', 'Facebook Ads', 3200.00, '2026-01-25', 'Campaign budget'),
('Hana', 'Marketing', 'Promotional Materials', 1500.00, '2026-02-03', 'Flyers and banners'),
('Karim', 'Marketing', 'Video Production', 7000.00, '2026-02-18', 'Product launch video'),

-- Operations Department
('Mostafa', 'Operations', 'Logistics Transport', 4200.00, '2026-01-28', 'Delivery services'),
('Mostafa', 'Operations', 'Warehouse Supplies', 1300.00, '2026-02-07', 'Storage materials'),
('Rania', 'Operations', 'Safety Equipment', 2100.00, '2026-02-16', 'Staff protection gear');
