
CREATE VIEW Accounting_Checks_Overview AS
     select OrganizationId, 'YearMonth' = CAST(YEAR(postat) AS VARCHAR(4)) + '-' + CAST(MONTH(postat) AS VARCHAR(2)),
		     'Count' = count(*),
		     'Total' = sum(Amount),
		     'Status' = status
     from accounting_checks
     group by
          OrganizationId,
          CAST(YEAR(postat) AS VARCHAR(4)) + '-' + CAST(MONTH(postat) AS VARCHAR(2)),
          Status