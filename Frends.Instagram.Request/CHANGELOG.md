# Changelog

## [2.0.0] - 2026-10-22
### Changed
- The Task now targets .NET 8.
- The Result now contains `Success` and `Error` properties. On failure with `ThrowErrorOnFailure` set to false, `Error.Message` and `Error.AdditionalInfo` describe the problem.
- `ThrowErrorOnFailure` now defaults to true.

### Added
- Added `ErrorMessageOnFailure` option for customizing the error message on failure.

## [1.1.0] - 2025-02-17
### Changed
- Update package System.ComponentModel.Annotations from 4.7.0 to 5.0.0
- Update package System.Runtime.Caching from 8.0.0 to 9.0.3

## [1.0.0] - 2023-01-29
### Changed
- Initial implementation
