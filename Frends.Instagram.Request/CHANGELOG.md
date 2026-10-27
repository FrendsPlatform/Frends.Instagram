# Changelog

## [2.0.0] - 2026-10-26
### Changed
- The Task now targets .NET 8.
- The Task result now includes `Success` and `Error` properties. When `ThrowErrorOnFailure` is false, errors are returned in `Error` instead of being thrown.
- **[Breaking Change]** `ThrowErrorOnFailure` now defaults to true.
- Added `ErrorMessageOnFailure` option for overriding the error message on failure.

## [1.1.0] - 2025-02-17
### Changed
- Update package System.ComponentModel.Annotations from 4.7.0 to 5.0.0
- Update package System.Runtime.Caching from 8.0.0 to 9.0.3

## [1.0.0] - 2023-01-29
### Changed
- Initial implementation
